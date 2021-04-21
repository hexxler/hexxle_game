using Hexxle.Logic;
using Hexxle.TileSystem;
using Hexxle.Interfaces;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

namespace Hexxle.Tests.Logic
{
    public class HandTests
    {
        Hand logicHand;
        TileStack stack;
        int handSize = 5;
        ITile[] firstTiles;

        [SetUp]
        public void Setup()
        {
            stack = new TileStack();
            stack.InitializeStack();

            firstTiles = new ITile[handSize];
            for (int i = 0; i < handSize; i++)
            {
                firstTiles[i] = stack.Pop();
            }

            logicHand = new Hand(handSize, firstTiles);
        }

        [Test]
        public void CheckFirstTiles()
        {
            CollectionAssert.AreEqual(firstTiles, logicHand.GetTiles());
        }

        [Test]
        public void CheckSelectTile()
        {
            Random rnd = new Random();
            int rndInt = rnd.Next(0, handSize);
            logicHand.SelectTile(firstTiles[rndInt]);
            Assert.True(logicHand.IsTileSelected());
            Assert.AreEqual(firstTiles[rndInt], logicHand.GetSelectedTile());
        }

        [Test]
        public void CheckEmptySlots()
        {
            Random rnd = new Random();
            int rndInt = rnd.Next(0, handSize);
            logicHand.SelectTile(firstTiles[rndInt]);
            ITile selectedTile = logicHand.ReplaceTile(null);
            Assert.AreEqual(selectedTile, firstTiles[rndInt]);
            Assert.AreEqual(1, logicHand.EmptySlots());
        }

        [Test]
        public void CheckFillHand()
        {
            logicHand.SelectTile(firstTiles[1]);
            logicHand.ReplaceTile(null);
            logicHand.SelectTile(firstTiles[3]);
            logicHand.ReplaceTile(null);
            ITile[] tiles = new Tile[2];
            tiles[0] = stack.Pop();
            tiles[1] = stack.Pop();
            logicHand.FillHand(tiles);
            firstTiles[1] = tiles[0];
            firstTiles[3] = tiles[1];
            CollectionAssert.AreEqual(firstTiles, logicHand.GetTiles());
        }

    }
}
