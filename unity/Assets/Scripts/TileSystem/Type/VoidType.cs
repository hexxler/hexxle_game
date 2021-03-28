using Assets.Scripts.Interfaces;
using Hexxle.TileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSystem.Type
{
    public class VoidType : ITileType
    {
        public EType Type => EType.Void;

        public int ValueOfRelationshipTo(EType otherType)
        {
            return 0;
        }
    }
}
