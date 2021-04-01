using NUnit.Framework;
using Hexxle.Logic;
using Hexxle.TileSystem;
using Hexxle.CoordinateSystem;


namespace Hexxle.Tests.Logic
{
    public class TileMapTests
    {

        TileMap tileMap;
        Tile tile;

        [SetUp]
        public void Setup()
        {
            tileMap = new TileMap();
            tile = Tile.CreateInstance(EState.None, EType.Red, ENature.Circle, EBehaviour.None);
        }

        [Test]
        public void UnplacedTilesAreEmpty()
        {
            Assert.IsTrue(tileMap.IsEmpty(new Coordinate()));
        }

        [Test]
        public void CoordinateWithTileIsNotEmpy()
        {
            tileMap.PlaceTile(tile, new Coordinate());
            Assert.IsFalse(tileMap.IsEmpty(new Coordinate()));
        }

        [Test]
        public void PlacedTileCanBeRetrieved()
        {
            Coordinate coordinate = new Coordinate(4, 3, 2);
            tileMap.PlaceTile(tile, coordinate);
            Assert.AreEqual(tile, tileMap.GetTile(coordinate));
        }

    }
}
