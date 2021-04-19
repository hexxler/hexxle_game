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
        List<Coordinate> expectedCoordinates;
        List<Coordinate> actualCoordinates;
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

            expectedCoordinates.AddRange(new List<Coordinate>
            {
                new Coordinate(coordinate.X + 1, coordinate.Y - 1, coordinate.Z),
                new Coordinate(coordinate.X + 1, coordinate.Y, coordinate.Z - 1),
                new Coordinate(coordinate.X - 1, coordinate.Y + 1, coordinate.Z),
                new Coordinate(coordinate.X - 1, coordinate.Y, coordinate.Z + 1),
                new Coordinate(coordinate.X, coordinate.Y - 1, coordinate.Z + 1),
                new Coordinate(coordinate.X, coordinate.Y + 1, coordinate.Z - 1)
            });

            actualCoordinates = tile.Nature.RelevantCoordinates(tile.Coordinate);

            expectedCoordinates.ForEach(coord =>
            {
                Assert.True(actualCoordinates.Contains(coord));
            });
        }

        [Test]
        public void RelevantCoordinates_Circle()
        {
            Coordinate origin = coordinate;

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Circle, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates.AddRange(tile.Nature.AdjacentCoordinates(tile.Coordinate));

            actualCoordinates = tile.Nature.RelevantCoordinates(origin);

            expectedCoordinates.ForEach(coord =>
            {
                Assert.True(actualCoordinates.Contains(coord));
            });
        }

        [Test]
        public void RelevantCoordinates_Star()
        {
            Coordinate origin = coordinate;

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Star, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates.AddRange(tile.Nature.AdjacentCoordinates(tile.Coordinate));
            expectedCoordinates.AddRange(new List<Coordinate>
            {
                new Coordinate(coordinate.X - 1, coordinate.Y - 1, coordinate.Z + 2),
                new Coordinate(coordinate.X + 1, coordinate.Y - 2, coordinate.Z + 1),
                new Coordinate(coordinate.X + 2, coordinate.Y - 1, coordinate.Z - 1),
                new Coordinate(coordinate.X + 1, coordinate.Y + 1, coordinate.Z - 2),
                new Coordinate(coordinate.X - 1, coordinate.Y + 2, coordinate.Z - 1),
                new Coordinate(coordinate.X - 2, coordinate.Y + 1, coordinate.Z + 1),
            });

            actualCoordinates = tile.Nature.RelevantCoordinates(origin);

            expectedCoordinates.ForEach(coord =>
            {
                Assert.True(actualCoordinates.Contains(coord));
            });
        }
    }
}
