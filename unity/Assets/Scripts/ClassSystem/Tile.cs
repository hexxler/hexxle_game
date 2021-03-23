namespace Hexxle.ClassSystem
{
    public class Tile
    {
        private readonly Breed _type;


        public Tile() : this(Breed.UNDEFINED)
        {

        }

        public Tile (Breed type) {
            _type = type;
        }


        public Breed Type { 
            get
            {
                return _type;
            }
        }
    }
}