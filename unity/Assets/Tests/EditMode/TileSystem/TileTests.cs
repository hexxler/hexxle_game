using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Hexxle.TileSystem.Behaviour;
using Hexxle.TileSystem.Nature;
using Hexxle.TileSystem.Type;
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

        [SetUp]
        public void SetUp()
        {
            tile = Tile.CreateInstance(EState.None, EType.None, ENature.None, EBehaviour.None);
        }

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

        [Test]
        public void AllEnumValuesImplemented_ENature()
        {
            var values = Enum.GetValues(typeof(ENature)).Cast<ENature>();
            foreach (ENature nature in values)
            {
                if (nature == ENature.None) continue;
                ITile tile = Tile.CreateInstance(EState.None, EType.None, nature, EBehaviour.None);
                Assert.NotNull(tile.Nature);
            }
        }

        [Test]
        public void AllEnumValuesImplemented_EType()
        {
            var values = Enum.GetValues(typeof(EType)).Cast<EType>();
            foreach (EType type in values)
            {
                if (type == EType.None) continue;
                ITile tile = Tile.CreateInstance(EState.None, type, ENature.None, EBehaviour.None);
                Assert.NotNull(tile.Type);
            }
        }

        [Test]
        public void AllEnumValuesImplemented_EBehaviour()
        {
            var values = Enum.GetValues(typeof(EBehaviour)).Cast<EBehaviour>();
            foreach (EBehaviour behaviour in values)
            {
                if (behaviour == EBehaviour.None) continue;
                ITile tile = Tile.CreateInstance(EState.None, EType.None, ENature.None, behaviour);
                Assert.NotNull(tile.Behaviour);
            }
        }

        [Test]
        public void TileChangedEventFires_State()
        {
            bool eventFired = false;
            tile.TileChangedEvent += () => eventFired = true;
            tile.State = EState.OnField;
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void TileChangedEventFires_Coordinate()
        {
            bool eventFired = false;
            tile.TileChangedEvent += () => eventFired = true;
            tile.Coordinate = new Coordinate(5, 5, 5);
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void TileChangedEventFires_Type()
        {
            bool eventFired = false;
            tile.TileChangedEvent += () => eventFired = true;
            tile.Type = new RedType();
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void TileChangedEventFires_Behaviour()
        {
            bool eventFired = false;
            tile.TileChangedEvent += () => eventFired = true;
            tile.Behaviour = new ConversionBehaviour();
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void TileChangedEventFires_Nature()
        {
            bool eventFired = false;
            tile.TileChangedEvent += () => eventFired = true;
            tile.Nature = new StarNature();
            Assert.IsTrue(eventFired);
        }
    }
}
