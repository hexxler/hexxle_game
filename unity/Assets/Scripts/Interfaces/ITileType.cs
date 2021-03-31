using Hexxle.TileSystem;

namespace Hexxle.Interfaces
{
    public interface ITileType
    {
        EType Type { get; }
        int ValueOfRelationshipTo(EType otherType);
    }
}
