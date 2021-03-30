using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Hexxle.CoordinateSystem;
using System;
using System.Collections.Generic;

namespace Hexxle.Logic
{
    public class TileMap : ITileMap<ITile>
    {
        private readonly Dictionary<Coordinate, ITile> _axisDictionary = new Dictionary<Coordinate, ITile>();

        public event EventHandler<TileMapEventArgs<ITile>> TilePlaced;
        public event EventHandler<TileMapEventArgs<ITile>> TileRemoved;

        public ITile GetTile(Coordinate coordinate)
        {
            if (IsEmpty(coordinate))
            {
                ITile tile = Tile.CreateInstance(EState.OnField, EType.Void, ENature.None, EBehaviour.None);
                tile.Coordinate = coordinate;
            }
            return _axisDictionary[coordinate];
        }

        public void PlaceTile(ITile tile, Coordinate coordinate)
        {
            tile.State = EState.OnField;
            tile.Coordinate = coordinate;
            _axisDictionary[coordinate] = tile;
            TilePlaced?.Invoke(this, new TileMapEventArgs<ITile>(this, tile));
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            return (!_axisDictionary.ContainsKey(coordinate));
        }

        public ITile RemoveTile(ITile tile)
        {
            throw new NotImplementedException();
        }
    }
}
