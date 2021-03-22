namespace Hexxle.ClassSystem
{
    public class Tile
    {
        private readonly Breed _type;

        public Tile () {
            _type = Breed.Void;
        }

        public Tile (Breed type) {
            _type = type;
        }


        public Breed Type { get; }
    }
}