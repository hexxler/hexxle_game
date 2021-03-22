namespace Hexxle.CoordinateSystem
{
    public class Hexagonal<T> where T : class, new()
    {
        private Axes<Axes<Axes<T>>> _axes = new Axes<Axes<Axes<T>>>();


        public T this[int X, int Y, int Z]
        {
            get => _axes[X][Y][Z];
            set => _axes[X][Y][Z] = value;
        }


        public T this[Coordinate coordinate]
        {
            get => this[coordinate.x, coordinate.y, coordinate.z];
            set => this[coordinate.x, coordinate.y, coordinate.z] = value;
        }

    }
}