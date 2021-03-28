using Assets.Scripts.Logic;
using Hexxle.CoordinateSystem;
using Hexxle.TileSystem;
using System;

namespace Assets.Scripts.Interfaces
{
    public interface ITileMap<T> where T : class, ITile
    {
        void PlaceTile(T tile, Coordinate coordinate);
        T RemoveTile(T tile);
        T GetTile(Coordinate coordinate);
        bool IsEmpty(Coordinate coordinate);
        event EventHandler<TileMapEventArgs<T>> TilePlaced;
        event EventHandler<TileMapEventArgs<T>> TileRemoved;
    }

    public class TileMapEventArgs<T> : EventArgs where T : class, ITile
    {
        public TileMapEventArgs(ITileMap<T> tileMap, T tile)
        {
            Map = tileMap;
            Tile = tile;
        }

        public ITileMap<T> Map { get; set; }
        public T Tile { get; set; }
    }
}
