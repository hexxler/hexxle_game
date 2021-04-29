using Hexxle.TileSystem;

namespace Hexxle.Interfaces
{
    public interface ITileType : IFunctionalValues
    {
        EType Type { get; }
        int ValueOfRelationshipTo(EType otherType);
    }
}
