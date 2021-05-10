using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            stack.InitializeStack();
            randomTileGenerator = new RandomTileGenerator();
        }

        [Test]
        public void InitializeStackTest()
        {
            ITileStack newStack = new TileStack();
            newStack.InitializeStack();
            Assert.IsTrue(newStack.Count() == 30);
        }

        [Test]
        public void PushTilesTest()
        {
            var newTilesList = new List<ITile>();
            var stackSize = stack.Count();
            for(int i = 0; i < 3; i++)
            {
                newTilesList.Add(generateTile());
            }
            var lastTile = newTilesList.Last();
            stack.PushTiles(newTilesList);
            Assert.AreEqual(lastTile, stack.Peek());
            Assert.IsTrue(stack.Count() == (stackSize + 3));
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
            Assert.IsTrue(stackSize == stack.Count());

        }

        [Test]
        public void GetFirstTenTilesTest()
        {
            var topTile = stack.Peek();
            var topTenTiles = stack.GetFirstTenTiles();
            Assert.IsTrue(topTenTiles.Count == 10);
            Assert.AreEqual(topTile, topTenTiles.Last());
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