using Assets.Scripts.Logic;
using Assets.Scripts.Interfaces;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Hexxle.Tests.Logic
{
    public class ScoreTests
    {
        IGameScore score;

        [SetUp]
        public void Setup()
        {
            score = new Score();
        }

        [Test]
        public void Score_IncreaseScore_Increase()
        {
            var oldScore = score.GetCurrentScore();
            score.IncreaseScore(1);
            var newScore = score.GetCurrentScore();
            Assert.IsTrue(newScore > oldScore);
        }

        [Test]
        public void Score_IncreaseScore_Decrease()
        {
            score.IncreaseScore(5);
            var oldScore = score.GetCurrentScore();
            score.IncreaseScore(-1);
            var newScore = score.GetCurrentScore();
            Assert.IsTrue(newScore < oldScore);
        }

        [Test]
        public void Score_IncreaseScore_BelowZero()
        {
            var oldScore = score.GetCurrentScore();
            score.IncreaseScore(-1);
            var newScore = score.GetCurrentScore();
            Assert.IsTrue(oldScore == 0);
            Assert.IsTrue(newScore == 0);
        }

        [Test]
        public void Score_ThresholdIncreases()
        {
            var oldThreshold = score.GetNextScoreThreshold();
            score.IncreaseScore(score.PointsUntilNextThreshold());
            var newThreshold = score.GetNextScoreThreshold();
            Assert.IsTrue(newThreshold > oldThreshold);
        }

        [Test]
        public void Score_PointsUntilNextThreshold_Increase()
        {
            var pointsBeforeIncrease = score.PointsUntilNextThreshold();
            score.IncreaseScore(1);
            var pointsAfterIncrease = score.PointsUntilNextThreshold();
            Assert.IsTrue(pointsBeforeIncrease > pointsAfterIncrease);
        }

        [Test]
        public void Score_PointsUntilNextThreshold_Decrease()
        {
            score.IncreaseScore(5);
            var pointsBeforeIncrease = score.PointsUntilNextThreshold();
            score.IncreaseScore(-1);
            var pointsAfterIncrease = score.PointsUntilNextThreshold();
            Assert.IsTrue(pointsBeforeIncrease < pointsAfterIncrease);
        }
    }
}
