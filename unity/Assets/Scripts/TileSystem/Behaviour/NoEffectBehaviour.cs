using Hexxle.Interfaces;

namespace Hexxle.TileSystem.Behaviour
{
    public class NoEffectBehaviour : ITileBehaviour
    {
        public EBehaviour Behaviour => EBehaviour.NoEffect;

        public void ApplyBehaviour(ITile originalTile, ITile otherTile)
        {
            // Do nothing
        }
    }
}
