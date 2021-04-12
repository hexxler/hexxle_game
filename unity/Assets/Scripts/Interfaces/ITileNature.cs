using Hexxle.CoordinateSystem;
using Hexxle.TileSystem;
using System.Collections.Generic;

namespace Hexxle.Interfaces
{
    public interface ITileNature
    {
        ENature Nature { get; }
        List<Coordinate> RelevantCoordinates(Coordinate coordinate);
        List<Coordinate> AdjacentCoordinates(Coordinate coordinate);
    }
}
