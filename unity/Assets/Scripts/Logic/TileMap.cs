using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem;
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

            if (tile.Type.Type > EType.Void)
            {
                // Place necessary void neighbours
                var neighbours = tile.Coordinate.AdjacentCoordinates();
                foreach (Coordinate neighbouringCoordinate in neighbours)
                {
                    if (IsEmpty(neighbouringCoordinate))
                    {
                        ITile neighbouringVoidTile = Tile.CreateInstance(EState.OnField, Tile.CreateType(EType.Void), Tile.CreateNature(ENature.None), Tile.CreateBehaviour(EBehaviour.None));
                        PlaceTile(neighbouringVoidTile, neighbouringCoordinate);
                    }
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

            // turn removed tile to void

            // check adjacent tiles
            IEnumerable<Coordinate> neighbours = coordinate.AdjacentCoordinates();
            IEnumerable<ITile> neighbouringTiles = neighbours.Select(c => GetTile(c)).Where(t => t != null);
            IEnumerable<ITile> neighbouringVoidTiles = neighbouringTiles.Where(t => t.Type.Type.Equals(EType.Void));
            IEnumerable<ITile> neighbouringTypedTiles = neighbouringTiles.Except(neighbouringVoidTiles);

            // remove orphaned adjacent void tiles
            foreach (ITile neighbouringTile in neighbouringVoidTiles)
            {
                if (IsOrphanedTile(neighbouringTile))
                {
                    _axisDictionary.Remove(neighbouringTile.Coordinate);
                    TileRemoved?.Invoke(this, new TileMapEventArgs<ITile>(this, neighbouringTile));
                    neighbouringTile.RemovalRequestedEvent -= RemoveTile;
                }
            }

            // notify removal
            TileRemoved?.Invoke(this, new TileMapEventArgs<ITile>(this, tile));
            tile.RemovalRequestedEvent -= RemoveTile;

            // replace old tile with void tile, if there are adjacent typed tiles
            if (neighbouringTypedTiles.Count() > 0)
            {
                ITile newVoidTile = Tile.CreateInstance(EState.OnField, Tile.CreateType(EType.Void), Tile.CreateNature(ENature.None), Tile.CreateBehaviour(EBehaviour.None));
                PlaceTile(newVoidTile, coordinate);
            }
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
