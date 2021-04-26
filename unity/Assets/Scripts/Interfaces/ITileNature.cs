using Hexxle.CoordinateSystem;
using Hexxle.TileSystem;
using System.Collections.Generic;

namespace Hexxle.Interfaces
{
    public interface ITileNature
    {
        ENature Nature { get; }
        IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate);
    }
}
