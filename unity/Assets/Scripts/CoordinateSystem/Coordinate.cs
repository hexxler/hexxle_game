namespace Hexxle.CoordinateSystem
{
    public struct Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }


        public Coordinate(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}