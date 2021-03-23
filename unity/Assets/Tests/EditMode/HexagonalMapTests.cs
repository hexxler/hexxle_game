using NUnit.Framework;
using Hexxle.CoordinateSystem;
using Hexxle.ClassSystem;

namespace Tests
{
    public class HexagonalMapTests
    {

        private HexagonalMap map;

        [SetUp]
        public void Setup()
        {
            map = new HexagonalMap();
        }

        [Test]
        public void IsEmptyReturnsTrueForUnsetTile()
        {
            Assert.IsTrue(map.IsEmpty(new Coordinate()));
        }

        [Test]
        public void IsEmptyReturnsFalseForSetTile()
        {
            Coordinate coordinate = new Coordinate();
            map[coordinate] = new Tile(Breed.Red);
            Assert.IsFalse(map.IsEmpty(coordinate));
        }


        [Test]
        public void CheckingForAnUnsetCoordinateReturnsTileOfTypeUndefined()
        {
            Assert.IsTrue(map[new Coordinate()].Type.Equals(Breed.UNDEFINED));
        }

        [Test]
        public void SettingATileAtCoordinateReturnsCorrectTileAgain()
        {
            Tile tile = new Tile(Breed.Blue);
            Coordinate coordinate = new Coordinate(1, 2, 3);
            map[coordinate] = tile;
            Assert.AreEqual(tile, map[coordinate]);
        }

        [Test]
        public void SettingANewTileSetsAllTilesThatConnectToItToUndefined()
        {
            Tile startTile = new Tile(Breed.Blue);
            Tile endTile = new Tile(Breed.Red);
            Coordinate startCoordinate = new Coordinate(0, 0, 0);
            Coordinate middleCoordinate = new Coordinate(1, 0, -1);
            Coordinate endCoordinate = new Coordinate(2, 0, -2);
            map[startCoordinate] = startTile;
            map[endCoordinate] = endTile;
            Assert.AreEqual(startTile, map[startCoordinate]);
            Assert.AreEqual(endTile, map[endCoordinate]);
            Assert.IsTrue(map[middleCoordinate].Type.Equals(Breed.UNDEFINED));

        }

    }

}
