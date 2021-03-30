using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hexxle.UnitTest
{
    [TestClass]
    public class TileTest
    {

        [TestMethod]
        public void TestMethod_CreateInstance()
        {
            Random r = new Random();
            EState expectedState = (EState)r.Next(1, Enum.GetValues(typeof(EState)).Length);
            EType expectedType = (EType)r.Next(1, Enum.GetValues(typeof(EType)).Length);
            ENature expectedNature = (ENature)r.Next(1, Enum.GetValues(typeof(ENature)).Length);
            EBehaviour expectedBehaviour = (EBehaviour)r.Next(1, Enum.GetValues(typeof(EBehaviour)).Length);

            ITile tile = Tile.CreateInstance(expectedState, expectedType, expectedNature, expectedBehaviour);
            Assert.AreEqual(expectedState, tile.State);
            Assert.AreEqual(expectedType, tile.Type.Type);
            Assert.AreEqual(expectedNature, tile.Nature.Nature);
            Assert.AreEqual(expectedBehaviour, tile.Behaviour.Behaviour);
        }
    }
}
