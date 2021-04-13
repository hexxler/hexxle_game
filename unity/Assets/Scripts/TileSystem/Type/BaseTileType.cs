using Hexxle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Type
{
    public abstract class BaseTileType : ITileType
    {
        protected readonly static int[][] TypeRelationships = LoadRelationShips();

        public abstract EType Type { get; }

        public int ValueOfRelationshipTo(EType otherType)
        {
            return TypeRelationships[(int)Type][(int)otherType];
        }

        private static int[][] LoadRelationShips()
        {
            var values = Enum.GetValues(typeof(EType)).Cast<EType>();
            int[][] relationships = new int[values.Count()][];
            for (int i = 0; i < values.Count(); i++)
            {
                relationships[i] = TileRelationship(values.ElementAt(i));
            }
            return relationships;
        }

        private static int[] TileRelationship(EType type)
        {
            int[] relationship;
            switch (type)
            {
                case EType.None:
                    relationship = TileRelationship(0, 0, 0, 0, 0, 0, 0);
                    break;
                case EType.Void:
                    relationship = TileRelationship(0, 0, 0, 0, 0, 0, 0);
                    break;
                case EType.Red:
                    relationship = TileRelationship(0, 0, 0, -1, 1, 2, -2);
                    break;
                case EType.Blue:
                    relationship = TileRelationship(0, 0, 1, 1, -2, 0, 3);
                    break;
                case EType.Green:
                    relationship = TileRelationship(0, 0, -1, -1, +2, 4, -5);
                    break;
                case EType.Violet:
                    relationship = TileRelationship(0, 0, -1, -1, 5, 2, -3);
                    break;
                case EType.Yellow:
                    relationship = TileRelationship(0, 0, 3, 3, -3, -3, -3);
                    break;
                default:
                    throw new ArgumentException("Type relationship not yet declared");
                    break;
            }
            return relationship;
        }

        private static int[] TileRelationship(int none, int vvoid, int red, int blue, int green, int violet, int yellow)
        {
            return new int[]
                {
                    none,
                    vvoid,
                    red,
                    blue,
                    green,
                    violet,
                    yellow
                };
        }
    }
}
