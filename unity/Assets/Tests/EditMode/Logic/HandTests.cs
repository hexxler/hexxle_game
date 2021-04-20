using Hexxle.Logic;
using Hexxle.Interfaces;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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

    }
}
