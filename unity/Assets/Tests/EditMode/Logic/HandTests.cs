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
        Hand LogicHand;
        TileStack Stack;
        int HandSize = 5;
        ITile[] FirstTiles;

        [SetUp]
        public void Setup()
        {
            Stack = new TileStack();
            Stack.InitializeStack();

            FirstTiles = new ITile[HandSize];
            for (int i = 0; i < HandSize; i++)
            {
                FirstTiles[i] = Stack.Pop();
            }

            LogicHand = new Hand(HandSize, FirstTiles);
        }

        [Test]
        public void CheckFirstTiles()
        {
            CollectionAssert.AreEqual(FirstTiles, LogicHand.GetTiles());
        }

        [Test]
        public void CheckSelectTile()
        {
            Random rnd = new Random();
            int rndInt = rnd.Next(0, HandSize);
            LogicHand.SelectTile(FirstTiles[rndInt]);
            Assert.True(LogicHand.IsTileSelected());
            Assert.AreEqual(FirstTiles[rndInt], LogicHand.GetSelectedTile());
        }

        [Test]
        public void CheckEmptySlots()
        {
            Random rnd = new Random();
            int rndInt = rnd.Next(0, HandSize);
            LogicHand.SelectTile(FirstTiles[rndInt]);
            ITile selectedTile = LogicHand.ReplaceTile(null);
            Assert.AreEqual(selectedTile, FirstTiles[rndInt]);
            Assert.AreEqual(1, LogicHand.EmptySlots());
        }

        [Test]
        public void CheckFillHand()
        {
            LogicHand.SelectTile(FirstTiles[1]);
            LogicHand.ReplaceTile(null);
            LogicHand.SelectTile(FirstTiles[3]);
            LogicHand.ReplaceTile(null);
            ITile[] tiles = new Tile[2];
            tiles[0] = Stack.Pop();
            tiles[1] = Stack.Pop();
            LogicHand.FillHand(tiles);
            FirstTiles[1] = tiles[0];
            FirstTiles[3] = tiles[1];
            CollectionAssert.AreEqual(FirstTiles, LogicHand.GetTiles());
        }

    }
}
