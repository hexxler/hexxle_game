using Hexxle.TileSystem;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Hexxle.Tests.Logic
{
    public class RandomTileGeneratorTests
    {

        [Test]
        public void SupplyingASeedShouldAlwaysGenerateTheSameTiles()
        {
            int seed = 1234567890;
            int amountOfTilesToCompare = 100;
            RandomTileGenerator generator = new RandomTileGenerator(seed);
            List<Tile> tilesOfFirstGenerator = new List<Tile>();
            List<Tile> tilesOfSecondGenerator = new List<Tile>();
            for (int i = 0; i < amountOfTilesToCompare; i++)
            {
                tilesOfFirstGenerator.Add(generator.GenerateRandomTile());
            }

            generator = new RandomTileGenerator(seed);
            for (int i = 0; i < amountOfTilesToCompare; i++)
            {
                tilesOfSecondGenerator.Add(generator.GenerateRandomTile());
            }

            for (int i = 0; i < tilesOfFirstGenerator.Count; i++)
            {
                Assert.IsTrue(tilesOfFirstGenerator[i].Equals(tilesOfSecondGenerator[i]));
            }
        }

    }
}
