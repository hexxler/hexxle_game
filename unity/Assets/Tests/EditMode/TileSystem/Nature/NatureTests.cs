using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.Tests.TileSystem.Nature
{
    public class NatureTests
    {
        ITile tile;
        IEnumerable<Coordinate> expectedCoordinates;
        IEnumerable<Coordinate> actualCoordinates;
        Coordinate coordinate;

        [SetUp]
        public void Setup()
        {
            Random r = new Random();
            var x = r.Next(-100, 100);
            var y = r.Next(-100, 100);
            var z = 0 - x - y;
            tile = null;
            expectedCoordinates = new List<Coordinate>();
            actualCoordinates = new List<Coordinate>();
            coordinate = new Coordinate(x, y, z);
        }

        [Test]
        public void AdjacentCoordinates()
        {
            Coordinate origin = coordinate;

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Circle, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates = expectedCoordinates.Union(new List<Coordinate>
            {
                new Coordinate(coordinate.X + 1, coordinate.Y - 1, coordinate.Z),
                new Coordinate(coordinate.X + 1, coordinate.Y, coordinate.Z - 1),
                new Coordinate(coordinate.X - 1, coordinate.Y + 1, coordinate.Z),
                new Coordinate(coordinate.X - 1, coordinate.Y, coordinate.Z + 1),
                new Coordinate(coordinate.X, coordinate.Y - 1, coordinate.Z + 1),
                new Coordinate(coordinate.X, coordinate.Y + 1, coordinate.Z - 1)
            });

            actualCoordinates = tile.Nature.RelevantCoordinates(tile.Coordinate, 0);

            foreach (Coordinate coord in actualCoordinates)
            {
                Assert.True(expectedCoordinates.Contains(coord));
            }
        }

        [Test]
        public void RelevantCoordinates_Circle()
        {
            Coordinate origin = coordinate;

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Circle, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates = expectedCoordinates.Union(tile.Coordinate.AdjacentCoordinates());

            actualCoordinates = tile.Nature.RelevantCoordinates(origin, 0);

            foreach (Coordinate coord in actualCoordinates)
            {
                Assert.True(expectedCoordinates.Contains(coord));
            }
        }

        [Test]
        public void RelevantCoordinates_Star()
        {
            Coordinate origin = coordinate;

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Star, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates = expectedCoordinates.Union(tile.Coordinate.AdjacentCoordinates());
            expectedCoordinates = expectedCoordinates.Union(new List<Coordinate>
            {
                new Coordinate(coordinate.X - 1, coordinate.Y - 1, coordinate.Z + 2),
                new Coordinate(coordinate.X + 1, coordinate.Y - 2, coordinate.Z + 1),
                new Coordinate(coordinate.X + 2, coordinate.Y - 1, coordinate.Z - 1),
                new Coordinate(coordinate.X + 1, coordinate.Y + 1, coordinate.Z - 2),
                new Coordinate(coordinate.X - 1, coordinate.Y + 2, coordinate.Z - 1),
                new Coordinate(coordinate.X - 2, coordinate.Y + 1, coordinate.Z + 1),
            });

            actualCoordinates = tile.Nature.RelevantCoordinates(origin, 0);

            foreach (Coordinate coord in actualCoordinates)
            {
                Assert.True(expectedCoordinates.Contains(coord));
            }
        }
    }
}
