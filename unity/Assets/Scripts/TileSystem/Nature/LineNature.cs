using Hexxle.CoordinateSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Nature
{
    public class LineNature : BaseTileNature
    {
        public override ENature Nature => ENature.Line;

        public override int CalculateWeight()
        {
            return RelevantCoordinates(new Coordinate(), 0).Count();
        }

        public override IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate, int rotation)
        {
            var relevantCoordinates = new List<Coordinate>
            {
                new Coordinate(coordinate.X - 1, coordinate.Y + 1, coordinate.Z),
                new Coordinate(coordinate.X - 2, coordinate.Y + 2, coordinate.Z),
                new Coordinate(coordinate.X + 1, coordinate.Y - 1, coordinate.Z),
                new Coordinate(coordinate.X + 2, coordinate.Y - 2, coordinate.Z),
            };
            return relevantCoordinates;
        }
    }
}
