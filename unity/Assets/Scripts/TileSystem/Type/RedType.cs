using Hexxle.Interfaces;

namespace Hexxle.TileSystem.Type
{
    public class RedType : ITileType
    {
        public EType Type => EType.Red;

        public int ValueOfRelationshipTo(EType otherType)
        {
            int result;
            switch (otherType)
            {
                case EType.Red:
                    result = 0;
                    break;
                case EType.Blue:
                    result = -1;
                    break;
                case EType.Green:
                    result = 1;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}
