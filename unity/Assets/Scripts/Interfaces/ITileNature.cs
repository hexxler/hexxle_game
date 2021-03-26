using Assets.Scripts.TileSystem;
using Hexxle.CoordinateSystem;
using System.Collections.Generic;

namespace Assets.Scripts.Interfaces
{
    public interface ITileNature
    {
        ENature Nature { get; }
        List<Coordinate> RelevantCoordinates(Coordinate coordinate);
        List<Coordinate> AdjacentCoordinates(Coordinate coordinate);
    }
}
