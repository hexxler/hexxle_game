﻿using Hexxle.CoordinateSystem;
using System;

namespace Hexxle.Interfaces
{
    public interface ITileMap<T> where T : class, ITile
    {
        void PlaceTile(T tile, Coordinate coordinate);
        void RemoveTile(Coordinate coordinate);
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
