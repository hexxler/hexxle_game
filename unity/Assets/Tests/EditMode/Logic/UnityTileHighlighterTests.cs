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
        public void TurningHighlighterOnSetsInteralVariableToTrueAndSetToBlackOnceToFalse()
        {
            Assert.IsFalse(tileHighlighter.isHighlighted);
            tileHighlighter.TurnOn();
            Assert.IsTrue(tileHighlighter.isHighlighted);
            Assert.IsFalse(tileHighlighter.setToBlackOnce);

        }

        [Test]
        public void TurningHighlighterOffSetsInteralVariableToFalseAndSetToBlackOnceToTrue()
        {
            Assert.IsFalse(tileHighlighter.isHighlighted);
            tileHighlighter.TurnOn();
            Assert.IsTrue(tileHighlighter.isHighlighted);
            Assert.IsFalse(tileHighlighter.setToBlackOnce);
            tileHighlighter.TurnOff();
            Assert.IsFalse(tileHighlighter.isHighlighted);
            Assert.IsTrue(tileHighlighter.setToBlackOnce);

        }
    }
}
