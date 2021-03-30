using Hexxle.Interfaces;
using Hexxle.TileSystem;

namespace Hexxle.TileSystem.Type
{
    public class BlueType : ITileType
    {
        public EType Type => EType.Blue;

        public int ValueOfRelationshipTo(EType otherType)
        {
            int result;
            switch (otherType)
            {
                case EType.Red:
                    result = 1;
                    break;
                case EType.Blue:
                    result = 1;
                    break;
                case EType.Green:
                    result = -2;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}
