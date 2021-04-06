using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface IScore
    {
        void IncreaseScore(int amount);
        int GetCurrentScore();
        int GetNextScoreThreshold();
    }
}
