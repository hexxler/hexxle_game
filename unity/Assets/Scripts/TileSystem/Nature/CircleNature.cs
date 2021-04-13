using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System.Collections.Generic;

namespace Hexxle.TileSystem.Nature
{
    public class CircleNature : ITileNature
    {
        public ENature Nature => ENature.Circle;

        public List<Coordinate> RelevantCoordinates(Coordinate coordinate)
        {
            return AdjacentCoordinates(coordinate);
        }

        public List<Coordinate> AdjacentCoordinates(Coordinate coordinate)
        {
            var relevantCoordinates = new List<Coordinate>
            {
                new Coordinate(coordinate.X + 1, coordinate.Y - 1, coordinate.Z),
                new Coordinate(coordinate.X + 1, coordinate.Y, coordinate.Z - 1),
                new Coordinate(coordinate.X, coordinate.Y + 1, coordinate.Z - 1),
                new Coordinate(coordinate.X - 1, coordinate.Y + 1, coordinate.Z),
                new Coordinate(coordinate.X - 1, coordinate.Y, coordinate.Z + 1),
                new Coordinate(coordinate.X, coordinate.Y - 1, coordinate.Z + 1),
            };
            return relevantCoordinates;
        }
    }
}
