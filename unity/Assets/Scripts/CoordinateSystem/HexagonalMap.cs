using Hexxle.ClassSystem;

namespace Hexxle.CoordinateSystem
{
    public class HexagonalMap
    {
        private Axes<Axes<Axes<Tile>>> _axes = new Axes<Axes<Axes<Tile>>>();


        public Tile this[int X, int Y, int Z]
        {
            get => _axes[X][Y][Z];
            set => _axes[X][Y][Z] = value;
        }

        public Tile this[Coordinate coordinate]
        {
            get => this[coordinate.x, coordinate.y, coordinate.z];
            set => this[coordinate.x, coordinate.y, coordinate.z] = value;
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            return _axes[coordinate.x][coordinate.y][coordinate.z].Type.Equals(Breed.UNDEFINED);
        }

    }
}