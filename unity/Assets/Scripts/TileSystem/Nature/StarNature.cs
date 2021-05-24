using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Nature
{
    public class StarNature : BaseTileNature
    {
        public override ENature Nature => ENature.Star;

        public override int CalculateWeight()
        {
            return RelevantCoordinates(new Coordinate(), 0).Count()-2;
        }

        public override IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate, int rotation)
        {
            var relevantCoordinates = coordinate.AdjacentCoordinates();
            relevantCoordinates = relevantCoordinates.Concat(new List<Coordinate>
            {
                new Coordinate(coordinate.X - 1, coordinate.Y - 1, coordinate.Z + 2),
                new Coordinate(coordinate.X + 1, coordinate.Y - 2, coordinate.Z + 1),
                new Coordinate(coordinate.X + 2, coordinate.Y - 1, coordinate.Z - 1),
                new Coordinate(coordinate.X + 1, coordinate.Y + 1, coordinate.Z - 2),
                new Coordinate(coordinate.X - 1, coordinate.Y + 2, coordinate.Z - 1),
                new Coordinate(coordinate.X - 2, coordinate.Y + 1, coordinate.Z + 1),
            });
            if (rotation != 0)
            {
                relevantCoordinates = relevantCoordinates.Select(c => Coordinate.RotateRight(coordinate, c, rotation));
            }
            return relevantCoordinates;
        }
    }
}
