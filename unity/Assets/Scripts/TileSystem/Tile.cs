using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem.Behaviour;
using Hexxle.TileSystem.Nature;
using Hexxle.TileSystem.Type;
using System;

namespace Hexxle.TileSystem
{
    public class Tile : ITile
    {
        private Coordinate _coordinate;
        private EState _state;
        private ITileType _type;
        private ITileBehaviour _behaviour;
        private ITileNature _nature;

        public event Action TileChangedEvent;
        public event Action<Coordinate> RemovalRequestedEvent;

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

        public static Tile CreateInstance(EState state, ITileType type, ITileNature nature, ITileBehaviour behaviour)
        {
            Tile tile = new Tile();
            tile.State = state;
            tile.Type = type;
            tile.Nature = nature;
            tile.Behaviour = behaviour;
            return tile;
        }


        public static ITileBehaviour CreateBehaviour(EBehaviour behaviour)
        {
            ITileBehaviour tileBehaviour;
            switch (behaviour)
            {
                case EBehaviour.NoEffect:
                    tileBehaviour = new NoEffectBehaviour();
                    break;
                case EBehaviour.Conversion:
                    tileBehaviour = new ConversionBehaviour();
                    break;
                case EBehaviour.Consumption:
                    tileBehaviour = new ConsumptionBehaviour();
                    break;
                case EBehaviour.None:
                default:
                    tileBehaviour = null;
                    break;
            }
            return tileBehaviour;
        }

        public static ITileNature CreateNature(ENature nature)
        {
            ITileNature tileNature;
            switch (nature)
            {
                case ENature.Circle:
                    tileNature = new CircleNature();
                    break;
                case ENature.Star:
                    tileNature = new StarNature();
                    break;
                case ENature.None:
                default:
                    tileNature = null;
                    break;
            }
            return tileNature;
        }

        public static ITileType CreateType(EType type)
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
                case EType.Violet:
                    tileType = new VioletType();
                    break;
                case EType.Yellow:
                    tileType = new YellowType();
                    break;
                case EType.Void:
                    tileType = new VoidType();
                    break;
                case EType.None:
                default:
                    tileType = null;
                    break;
            }
            return tileType;
        }

        public EState State
        {
            get => _state;
            set
            {
                _state = value;
                TileChangedEvent?.Invoke();
            }
        }

        public ITileType Type
        {
            get => _type;
            set
            {
                _type = value;
                TileChangedEvent?.Invoke();
            }
        }
        public ITileBehaviour Behaviour
        {
            get => _behaviour;
            set
            {
                _behaviour = value;
                TileChangedEvent?.Invoke();
            }
        }
        public ITileNature Nature
        {
            get => _nature;
            set
            {
                _nature = value;
                TileChangedEvent?.Invoke();
            }
        }

        public Coordinate Coordinate
        {
            get => _coordinate;
            set
            {
                _coordinate = value;
                TileChangedEvent?.Invoke();
            }
        }

        public void RequestRemoval()
        {
            RemovalRequestedEvent?.Invoke(this.Coordinate);
        }

        public override bool Equals(object obj)
        {
            if (obj is Tile tile && tile.Behaviour != null && tile.Nature != null && tile.Type != null)
            {
                return this.Behaviour.Behaviour.Equals(tile.Behaviour.Behaviour)
                    && this.Nature.Nature.Equals(tile.Nature.Nature)
                    && this.Type.Type.Equals(tile.Type.Type);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 17;
            int prime = 23;
            hash = hash * prime + Behaviour.GetHashCode();
            hash = hash * prime + Nature.GetHashCode();
            hash = hash * prime + Type.GetHashCode();
            hash = hash * prime + Coordinate.GetHashCode();
            return hash;

        }

        public override string ToString()
        {
            return "B: " + Behaviour + " N: " + Nature + " T: " + Type;
        }
    }
}