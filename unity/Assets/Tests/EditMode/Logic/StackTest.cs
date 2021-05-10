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
            var stackSize = stack.Count();
            var newTile = generateTile();
            stack.Push(newTile);
            Assert.AreEqual(newTile, stack.Peek());
            Assert.IsTrue(stack.Count() == (stackSize + 1 ))

        }

        [Test]
        public void PopTest()
        {
            var stackSize = stack.Count();
            var topTilePeek = stack.Peek();
            var topTilePop = stack.Pop();
            Assert.AreEqual(topTilePeek, topTilePop);
            Assert.IsTrue((stackSize - 1) == stack.Count());
        }

        [Test]
        public void PeekTest()
        {
            var stackSize = stack.Count();
            var topTile = stack.Peek();
            Assert.IsTrue(stackSize == stack.Count())

        }

        [Test]
        public void GetFirstTenTilesTest()
        {
            var topTile = stack.Peek();
            var topTenTiles = stack.GetFirstTenTiles();
            Assert.IsTrue(topTenTiles.Count == 10);
            Assert.AreEqual(topTile, topTenTiles.First());
        }

        [Test]
        public void AddNewRandomTilesTest()
        {
            var stackSize = stack.Count();
            stack.AddNewRandomTiles(6);
            Assert.IsTrue((stackSize + 6) == stack.Count());
        }

        private ITile generateTile()
        {
            return randomTileGenerator.GenerateRandomTile();
        }
    }
}