using Assets.Scripts.Interfaces;
using Hexxle.CoordinateSystem;
using System.Collections.Generic;

namespace Assets.Scripts.TileSystem.Nature
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
                new Coordinate(coordinate.x + 1, coordinate.y - 1, coordinate.z),
                new Coordinate(coordinate.x + 1, coordinate.y, coordinate.z - 1),
                new Coordinate(coordinate.x, coordinate.y + 1, coordinate.z - 1),
                new Coordinate(coordinate.x - 1, coordinate.y + 1, coordinate.z),
                new Coordinate(coordinate.x - 1, coordinate.y, coordinate.z + 1),
                new Coordinate(coordinate.x, coordinate.y - 1, coordinate.z + 1),
            };
            return relevantCoordinates;
        }
    }
}
