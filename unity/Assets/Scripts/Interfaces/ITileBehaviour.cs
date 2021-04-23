using Hexxle.TileSystem;

namespace Hexxle.Interfaces
{
    public interface ITileBehaviour
    {
        EBehaviour Behaviour { get; }
        void ApplyBehaviour(ITile originalTile, ITile otherTile);
    }
}
