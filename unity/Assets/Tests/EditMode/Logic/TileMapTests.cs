using NUnit.Framework;
using Hexxle.Logic;
using Hexxle.TileSystem;
using Hexxle.CoordinateSystem;
using System.Linq;
using Hexxle.Interfaces;

namespace Hexxle.Tests.Logic
{
    public class TileMapTests
    {

        ITileMap<ITile> tileMap;
        ITile tile;

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

        [Test]
        public void PlacedTileHasVoidNeighbours()
        {
            Coordinate coordinate = new Coordinate(4, 3, 2);
            tileMap.PlaceTile(tile, coordinate);
            var neighbouringCoordinates = tile.Coordinate.AdjacentCoordinates();
            var neighbouringTiles = neighbouringCoordinates.Select(coord => tileMap.GetTile(coord)).Where(tile => tile != null);
            Assert.AreEqual(neighbouringTiles.Count(), 6);
            foreach (ITile neighbouringTile in neighbouringTiles)
            {
                Assert.IsTrue(neighbouringTile.Type.Type == EType.Void);
            }
        }

        [Test]
        public void PlacedTileCanBeRemoved()
        {
            Coordinate coordinate = new Coordinate(4, 3, 2);
            tileMap.PlaceTile(tile, coordinate);
            tileMap.RemoveTile(coordinate);
            Assert.IsNull(tileMap.GetTile(coordinate));
        }

        [Test]
        public void OrphanedTilesAreRemoved()
        {
            Coordinate coordinate = new Coordinate(4, 3, 2);
            tileMap.PlaceTile(tile, coordinate);
            tileMap.RemoveTile(coordinate);
            var neighbouringCoordinates = tile.Coordinate.AdjacentCoordinates();
            var neighbouringTiles = neighbouringCoordinates.Select(coord => tileMap.GetTile(coord)).Where(tile => tile != null);
            Assert.IsTrue(neighbouringTiles.Count() == 0);
        }

        [Test]
        public void RemovalRequestedEventRemovesTile()
        {
            Coordinate coordinate = new Coordinate(4, 3, 2);
            tileMap.PlaceTile(tile, coordinate);
            tile.RequestRemoval();
            Assert.IsNull(tileMap.GetTile(coordinate));
        }

        #region Issue specific tests
        [Test]
        public void PlaceTile_Hexxle91()
        {
            TileMap explicitTileMap = new TileMap();
            Coordinate c1 = new Coordinate(-8, -8, 16);
            Coordinate c2 = new Coordinate(-9, -8, 17);
            explicitTileMap.PlaceTile(tile, c1);
            explicitTileMap.PlaceTile(tile, c2);
            Assert.True(explicitTileMap.NonVoidTileCount() == 2);
        }
        #endregion
    }
}
