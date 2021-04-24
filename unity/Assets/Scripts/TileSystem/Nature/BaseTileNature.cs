using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Nature
{
    public abstract class BaseTileNature : ITileNature
    {
        public abstract ENature Nature { get; }

        public IEnumerable<Coordinate> AdjacentCoordinates(Coordinate coordinate)
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

        public abstract IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate);
    }
}
