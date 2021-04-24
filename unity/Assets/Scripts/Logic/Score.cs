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

        public int IncreaseScore(int amount)
        {
            int additionalTileCount = 0;
            _score += amount;
            _score = Math.Max(_lastThreshold, _score);
            while (_score >= _nextThreshold)
            {
                // TODO: implement points interval logic
                //       (next interval and allowing player to get more tiles)
                _lastThreshold = _nextThreshold;
                _nextThreshold += 10;
                additionalTileCount++;
            }
            return additionalTileCount;
        }

        public int PointsUntilNextThreshold()
        {
            return _nextThreshold - _score;
        }
    }
}
