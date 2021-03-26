using Assets.Scripts.Interfaces;
using Assets.Scripts.TileSystem;
using Hexxle.CoordinateSystem;
using Hexxle.TileSystem;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Logic
{
    public class TileMap : ITileMap<Tile>
    {
        private readonly Dictionary<Coordinate, Tile> _axisDictionary = new Dictionary<Coordinate, Tile>();

        public event EventHandler<TileMapEventArgs<Tile>> TilePlaced;
        public event EventHandler<TileMapEventArgs<Tile>> TileRemoved;

        public Tile GetTile(Coordinate coordinate)
        {
            if (IsEmpty(coordinate))
            {
                Tile tile = Tile.CreateInstance(EState.OnField, EType.Void, ENature.None, EBehaviour.None);
                tile.Coordinate = coordinate;
            }
            return _axisDictionary[coordinate];
        }

        public void PlaceTile(Tile tile, Coordinate coordinate)
        {
            tile.State = EState.OnField;
            tile.Coordinate = coordinate;
            _axisDictionary[coordinate] = tile;
            TilePlaced?.Invoke(this, new TileMapEventArgs<Tile>(this, tile));
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            return (!_axisDictionary.ContainsKey(coordinate));
        }

        public Tile RemoveTile(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}
