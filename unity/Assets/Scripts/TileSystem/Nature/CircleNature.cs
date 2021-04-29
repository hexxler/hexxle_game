using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.TileSystem.Nature
{
    public class CircleNature : BaseTileNature
    {
        public override ENature Nature => ENature.Circle;

        public override int CalculateWeight()
        {
            return RelevantCoordinates(new Coordinate()).Count();
        }

        public override IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate)
        {
            return coordinate.AdjacentCoordinates();
        }
    }
}
