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
            tile.RemovalRequestedEvent += RemoveTile;

            // Place necessary void neighbours
            var neighbours = tile.Coordinate.AdjacentCoordinates();
            foreach(Coordinate neighbouringCoordinate in neighbours)
            {
                if (IsEmpty(neighbouringCoordinate))
                {
                    ITile neighbouringVoidTile = Tile.CreateInstance(EState.OnField, EType.Void, ENature.None, EBehaviour.None);
                    neighbouringVoidTile.Coordinate = neighbouringCoordinate;
                    _axisDictionary[neighbouringCoordinate] = neighbouringVoidTile;
                    TilePlaced?.Invoke(this, new TileMapEventArgs<ITile>(this, neighbouringVoidTile));
                    neighbouringVoidTile.RemovalRequestedEvent += RemoveTile;
                }
            }
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            return (!_axisDictionary.ContainsKey(coordinate));
        }

        public void RemoveTile(Coordinate coordinate)
        {
            if (IsEmpty(coordinate)) return;

            ITile tile = _axisDictionary[coordinate];
            _axisDictionary.Remove(coordinate);

            // check adjacent tiles
            var neighbours = coordinate.AdjacentCoordinates();
            var neighbouringTiles = neighbours.Select(c => GetTile(c)).Where(t => t != null);
            foreach (ITile neighbouringTile in neighbouringTiles)
            {
                if (IsOrphanedTile(neighbouringTile))
                {
                    _axisDictionary.Remove(neighbouringTile.Coordinate);
                    TileRemoved?.Invoke(this, new TileMapEventArgs<ITile>(this, neighbouringTile));
                    neighbouringTile.RemovalRequestedEvent -= RemoveTile;
                }
            }
            TileRemoved?.Invoke(this, new TileMapEventArgs<ITile>(this, tile));
            tile.RemovalRequestedEvent -= RemoveTile;
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
