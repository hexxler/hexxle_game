using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Logic
{
    public class Score : IGameScore
    {
        private int _score;
        private int _nextThreshold;
        private int _lastThreshold;

        public Score()
        {
            _score = 0;
            _nextThreshold = 10;
            _lastThreshold = 0;
        }
        public int GetCurrentScore()
        {
            return _score;
        }

        public int GetNextScoreThreshold()
        {
            return _nextThreshold;
        }

        public void IncreaseScore(int amount)
        {
            _score += amount;
            _score = Math.Max(_lastThreshold, _score);
            if (_score >= _nextThreshold)
            {
                // TODO: implement interval logic
                _nextThreshold += 10;
            }
        }

        public int PointsUntilNextThreshold()
        {
            return _nextThreshold - _score;
        }
    }
}
