using Hexxle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Behaviour
{
    public class ConsumptionBehaviour : ITileBehaviour
    {
        public EBehaviour Behaviour => EBehaviour.Consumption;

        public void ApplyBehaviour(ITile originalTile, ITile otherTile)
        {
            if (!(otherTile.Type.Type is EType.Void))
            {
                otherTile.RequestRemoval();
            }
        }

        public int CalculateWeight()
        {
            return 8;
        }
    }
}
