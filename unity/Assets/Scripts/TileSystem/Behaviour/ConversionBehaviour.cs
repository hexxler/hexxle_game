using Hexxle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Behaviour
{
    public class ConversionBehaviour : ITileBehaviour
    {
        public EBehaviour Behaviour => EBehaviour.Conversion;

        public void ApplyBehaviour(ITile originalTile, ITile otherTile)
        {
            if (!(otherTile.Type.Type is EType.Void))
            {
                otherTile.Type = (ITileType)Activator.CreateInstance(originalTile.Type.GetType());
            }
        }

        public int CalculateWeight()
        {
            return 6;
        }
    }
}
