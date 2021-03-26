using Assets.Scripts.Interfaces;
using Assets.Scripts.TileSystem;
using Assets.Scripts.TileSystem.Nature;
using Assets.Scripts.TileSystem.Type;
using Hexxle.CoordinateSystem;

namespace Hexxle.TileSystem
{
    public class Tile : ITile
    {
        private Coordinate _coordinate;
        private EState _state;
        private ITileType _type;
        private ITileBehaviour _behaviour;
        private ITileNature _nature;

        private Tile()
        {
            _state = EState.None;
        }

        public static Tile CreateInstance(EState state, EType type, ENature nature, EBehaviour behaviour)
        {
            Tile tile = new Tile();
            tile.State = state;
            tile.Type = CreateType(type);
            tile.Nature = CreateNature(nature);
            tile.Behaviour = CreateBehaviour(behaviour);
            return tile;
        }

        private static ITileBehaviour CreateBehaviour(EBehaviour behaviour)
        {
            ITileBehaviour tileBehaviour;
            switch (behaviour)
            {
                case EBehaviour.NoEffect:
                default:
                    tileBehaviour = new NoEffectBehaviour();
                    break;
            }
            return tileBehaviour;
        }

        private static ITileNature CreateNature(ENature nature)
        {
            ITileNature tileNature;
            switch (nature)
            {
                case ENature.Circle:
                    tileNature = new CircleNature();
                    break;
                case ENature.None:
                default:
                    // TODO
                    tileNature = null;
                    break;
            }
            return tileNature;
        }

        private static ITileType CreateType(EType type)
        {
            ITileType tileType;
            switch (type)
            {
                case EType.Red:
                    tileType = new RedType();
                    break;
                case EType.Blue:
                    tileType = new BlueType();
                    break;
                case EType.Green:
                    tileType = new GreenType();
                    break;
                case EType.Void:
                    tileType = new VoidType();
                    break;
                case EType.None:
                default:
                    // TODO
                    tileType = null;
                    break;
            }
            return tileType;
        }

        public EState State
        {
            get => _state;
            set => _state = value;
        }
        public ITileType Type
        {
            get => _type;
            set => _type = value;
        }
        public ITileBehaviour Behaviour
        {
            get => _behaviour;
            set => _behaviour = value;
        }
        public ITileNature Nature
        {
            get => _nature;
            set => _nature = value;
        }
        public Coordinate Coordinate
        {
            get => _coordinate;
            set => _coordinate = value;
        }
    }
}