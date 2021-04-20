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
        Hand hand;
        TileStack stack;
        int HandSize = 5;
        List<ITile> FirstTiles;

        [SetUp]
        public void Setup()
        {
            stack = new TileStack();

            FirstTiles = new List<ITile>();
            for(int i = 0; i < HandSize; i++)
            {
                FirstTiles.Add(stack.Pop());
            }

            hand = new Hand(HandSize, FirstTiles);
        }

        [Test]
        public void CheckFirstTiles()
        {
            CollectionAssert.AreEqual(FirstTiles, hand.GetTiles());
        }

    }
}
