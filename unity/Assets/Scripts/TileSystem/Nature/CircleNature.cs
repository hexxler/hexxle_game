using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System.Collections.Generic;

namespace Hexxle.TileSystem.Nature
{
    public class CircleNature : BaseTileNature
    {
        public override ENature Nature => ENature.Circle;

        public override IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate)
        {
            return coordinate.AdjacentCoordinates();
        }
    }
}
