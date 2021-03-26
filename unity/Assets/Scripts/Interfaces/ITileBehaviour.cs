using Assets.Scripts.TileSystem;

namespace Assets.Scripts.Interfaces
{
    public interface ITileBehaviour
    {
        EBehaviour Behaviour { get; }
        void ApplyBehaviour(ITile otherTile);
    }
}
