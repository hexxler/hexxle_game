using Hexxle.Interfaces;
using Hexxle.TileSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.Tests.TileSystem.Behaviour
{
    public class BehaviourTests
    {
        ITile originalTile;
        ITile otherTile;

        [SetUp]
        public void Setup()
        {
            originalTile = null;
            otherTile = Tile.CreateInstance(EState.None, EType.Green, ENature.Circle, EBehaviour.None);
        }

        [Test]
        public void NoEffect()
        {
            EType expectedType = otherTile.Type.Type;

            originalTile = Tile.CreateInstance(EState.None, EType.Red, ENature.Circle, EBehaviour.NoEffect);
            originalTile.Behaviour.ApplyBehaviour(originalTile, otherTile);

            Assert.IsTrue(otherTile.Type.Type.Equals(expectedType));
        }

        [Test]
        public void Conversion()
        {
            originalTile = Tile.CreateInstance(EState.None, EType.Red, ENature.Circle, EBehaviour.Conversion);
            originalTile.Behaviour.ApplyBehaviour(originalTile, otherTile);

            EType expectedType = originalTile.Type.Type;
            Assert.IsTrue(otherTile.Type.Type.Equals(expectedType));
        }
    }
}
