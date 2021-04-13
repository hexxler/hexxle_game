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

        [SetUp]
        public void Setup()
        {
            tile = null;
            expectedCoordinates = new List<Coordinate>();
            actualCoordinates = new List<Coordinate>();
        }

        [Test]
        public void AdjacentCoordinates()
        {
            int origin_x = 5;
            int origin_y = -5;
            int origin_z = 0;
            Coordinate origin = new Coordinate(origin_x, origin_y, origin_z);

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Circle, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates.AddRange(new List<Coordinate>
            {
                new Coordinate(origin_x + 1, origin_y - 1, origin_z),
                new Coordinate(origin_x + 1, origin_y, origin_z - 1),
                new Coordinate(origin_x - 1, origin_y + 1, origin_z),
                new Coordinate(origin_x - 1, origin_y, origin_z + 1),
                new Coordinate(origin_x, origin_y - 1, origin_z + 1),
                new Coordinate(origin_x, origin_y + 1, origin_z - 1)
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
            int origin_x = 23;
            int origin_y = 0;
            int origin_z = -23;
            Coordinate origin = new Coordinate(origin_x, origin_y, origin_z);

            tile = Tile.CreateInstance(EState.None, EType.None, ENature.Circle, EBehaviour.None);
            tile.Coordinate = origin;

            expectedCoordinates.AddRange(tile.Nature.AdjacentCoordinates(tile.Coordinate));

            actualCoordinates = tile.Nature.RelevantCoordinates(origin);

            expectedCoordinates.ForEach(coord =>
            {
                Assert.True(actualCoordinates.Contains(coord));
            });
        }
    }
}
