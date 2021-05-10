using Hexxle.Interfaces;
using Hexxle.Logic;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexxle.Tests.Logic
{
    public class StackTest 
    {
        ITileStack stack;
        RandomTileGenerator randomTileGenerator;

        [SetUp]
        public void Setup()
        {
            stack = new TileStack();
            randomTileGenerator = new RandomTileGenerator();
        }

        [Test]
        public void InitializeStackTest()
        {
            stack.InitializeStack();
            Assert.IsTrue(stack.Count() == 30);
        }

        [Test]
        public void PushTilesTest()
        {
            newTilesList = new List<ITile>();
            var stackSize = stack.Count();
            for(int i = 0; i < 3; i++)
            {
                newTilesList.Add(generateTile);
            }
            var lastTile = newTilesList.Last();
            stack.PushTiles(newTilesList);
            Assert.AreEqual(lastTile, stack.Peek());
            Assert.IsTrue(stack.Count() == (stackSize + 3))
        }

        [Test]
        public void PushTest()
        {

        }

        [Test]
        public void PopTest()
        {

        }

        [Test]
        public void PeekTest()
        {

        }

        [Test]
        public void GetFirstTenTilesTest()
        {

        }

        [Test]
        public void AddNewRandomTilesTest()
        {

        }

        private ITile generateTile()
        {
            return randomTileGenerator.GenerateRandomTile();
        }
    }
}