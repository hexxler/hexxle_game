using Hexxle.TileSystem;

namespace Assets.Scripts.Interfaces
{
    public interface ITileType
    {
        EType Type { get; }
        int ValueOfRelationshipTo(EType otherType);
    }
}
