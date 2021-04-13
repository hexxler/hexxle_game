using NUnit.Framework;
using Hexxle.Unity;

namespace Hexxle.Tests.Unity
{
    public class UnityTileHighlighterTests
    {
        UnityTileHighlighter tileHighlighter;

        [SetUp]
        public void Setup()
        {
            tileHighlighter = new UnityTileHighlighter();
        }


        [Test]
        public void TurningHighlighterOnSetsInteralVariableToTrue()
        {
            Assert.IsFalse(tileHighlighter.isHighlighted);
            tileHighlighter.TurnOn();
            Assert.IsTrue(tileHighlighter.isHighlighted);

        }

        [Test]
        public void TurningHighlighterOffSetsInteralVariableToFalse()
        {
            Assert.IsFalse(tileHighlighter.isHighlighted);
            tileHighlighter.TurnOn();
            Assert.IsTrue(tileHighlighter.isHighlighted);
            tileHighlighter.TurnOff();
            Assert.IsFalse(tileHighlighter.isHighlighted);

        }
    }
}
