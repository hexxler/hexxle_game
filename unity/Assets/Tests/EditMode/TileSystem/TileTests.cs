using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Hexxle.TileSystem.Behaviour;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.Tests.TileSystem
{
    public class TileTests
    {
        ITile tile;

        [Test]
        public void CreateInstance_Test()
        {
            Random r = new Random();
            EState expectedState = (EState)r.Next(1, Enum.GetValues(typeof(EState)).Length);
            EType expectedType = (EType)r.Next(1, Enum.GetValues(typeof(EType)).Length);
            ENature expectedNature = (ENature)r.Next(1, Enum.GetValues(typeof(ENature)).Length);
            EBehaviour expectedBehaviour = (EBehaviour)r.Next(1, Enum.GetValues(typeof(EBehaviour)).Length);

            tile = Tile.CreateInstance(expectedState, expectedType, expectedNature, expectedBehaviour);
            Assert.AreEqual(expectedState, tile.State);
            Assert.AreEqual(expectedType, tile.Type.Type);
            Assert.AreEqual(expectedNature, tile.Nature.Nature);
            Assert.AreEqual(expectedBehaviour, tile.Behaviour.Behaviour);
        }

        public void CreateInstance_NoState()
        {
            tile = Tile.CreateInstance(EState.None, EType.None, ENature.None, EBehaviour.None);
            Assert.Equals(tile.State, EState.None);
        }

        public void CreateInstance_NoType()
        {
            tile = Tile.CreateInstance(EState.None, EType.None, ENature.None, EBehaviour.None);
            Assert.IsNull(tile.Type);
        }

        public void CreateInstance_NoNature()
        {
            tile = Tile.CreateInstance(EState.None, EType.None, ENature.None, EBehaviour.None);
            Assert.IsNull(tile.Nature);
        }

        public void CreateInstance_NoBehaviour()
        {
            tile = Tile.CreateInstance(EState.None, EType.None, ENature.None, EBehaviour.None);
            Assert.IsInstanceOf(typeof(NoEffectBehaviour), tile.Behaviour);
        }
    }
}
