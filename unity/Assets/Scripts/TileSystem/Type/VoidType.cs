using Hexxle.Interfaces;

namespace Hexxle.TileSystem.Type
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
