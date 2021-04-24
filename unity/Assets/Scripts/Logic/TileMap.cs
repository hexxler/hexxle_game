using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Hexxle.TileSystem.Type;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.Logic
{
    public class TileMap : ITileMap<ITile>
    {
        private readonly Dictionary<Coordinate, ITile> _axisDictionary = new Dictionary<Coordinate, ITile>();

        #region ITileMap interface implementation
        public event EventHandler<TileMapEventArgs<ITile>> TilePlaced;
        public event EventHandler<TileMapEventArgs<ITile>> TileRemoved;

        public ITile GetTile(Coordinate coordinate)
        {
            return IsEmpty(coordinate) ? null : _axisDictionary[coordinate];
        }

        public void PlaceTile(ITile tile, Coordinate coordinate)
        {
            tile.State = EState.OnField;
            tile.Coordinate = coordinate;
            _axisDictionary[coordinate] = tile;
            TilePlaced?.Invoke(this, new TileMapEventArgs<ITile>(this, tile));

            // Place necessary void neighbours
            var neighbours = tile.Coordinate.AdjacentCoordinates();
            foreach(Coordinate neighbouringCoordinate in neighbours)
            {
                if (IsEmpty(neighbouringCoordinate))
                {
                    ITile newVoidTile = Tile.CreateInstance(EState.OnField, EType.Void, ENature.None, EBehaviour.None);
                    newVoidTile.Coordinate = neighbouringCoordinate;
                    _axisDictionary[neighbouringCoordinate] = newVoidTile;
                    TilePlaced?.Invoke(this, new TileMapEventArgs<ITile>(this, newVoidTile));
                }
            }
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            return (!_axisDictionary.ContainsKey(coordinate));
        }

        public ITile RemoveTile(ITile tile)
        {
            _axisDictionary.Remove(tile.Coordinate);

            // check adjacent tiles
            var neighbours = tile.Coordinate.AdjacentCoordinates();
            var neighbouringTiles = neighbours.Select(c => GetTile(c)).Where(t => t != null);
            foreach (ITile neighbouringTile in neighbouringTiles)
            {
                if (IsOrphanedTile(neighbouringTile))
                {
                    _axisDictionary.Remove(neighbouringTile.Coordinate);
                    TileRemoved?.Invoke(this, new TileMapEventArgs<ITile>(this, neighbouringTile));
                }
            }
            TileRemoved?.Invoke(this, new TileMapEventArgs<ITile>(this, tile));
            return tile;
        }
        #endregion

        public int NonVoidTileCount()
        {
            return _axisDictionary.Where(kvp => kvp.Value.Type.Type > EType.Void).Count();
        }

        private bool IsOrphanedTile(ITile tile)
        {
            bool isOrphaned = false;
            if (!(tile.Type.Type > EType.Void))
            {
                var neighbours = tile.Coordinate.AdjacentCoordinates();
                var neighbouringTiles = neighbours.Select(c => GetTile(c)).Where(t => t != null);
                bool hasNonVoidNeighbours = neighbouringTiles.Any(t => t.Type.Type > EType.Void);
                isOrphaned = !hasNonVoidNeighbours;
            }
            return isOrphaned;
        }
    }
}
