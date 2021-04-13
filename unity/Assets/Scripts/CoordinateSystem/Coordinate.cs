using System;
using UnityEngine;

namespace Hexxle.CoordinateSystem
{
    public struct Coordinate
    {
        // Implementation heavily derived from https://www.redblobgames.com/grids/hexagons/
        public struct Hex
        {
            public float Q { get; }
            public float R { get; }
            
            public Hex(float q, float r)
            {
                this.Q = q;
                this.R = r;
            }
        }

        public struct Cube
        {
            public float X { get; }
            public float Y { get; }
            public float Z { get; }

            public Cube(float x, float y, float z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }

        private Hex _hex;
        private Cube _cube;

        public int Q => Convert.ToInt32(_hex.Q);
        public int R => Convert.ToInt32(_hex.R);
        public int X => Convert.ToInt32(_cube.X);
        public int Y => Convert.ToInt32(_cube.Y);
        public int Z => Convert.ToInt32(_cube.Z);

        public Coordinate(Hex hex)
        {
            this._hex = hex;
            this._cube = AxialToCube(hex);
        }

        public Coordinate(Cube cube)
        {
            this._cube = cube;
            this._hex = CubeToAxial(cube);
        }

        public Coordinate(int x, int y, int z) : this(new Cube(x, y, z)) { }
        public Coordinate(float x, float y, float z)
        {
            this._cube = CubeRound(new Cube(x, y, z));
            this._hex = CubeToAxial(this._cube);
        }

        private static Cube CubeRound(Cube cube)
        {
            // rounded values
            int rx = Mathf.RoundToInt(cube.X);
            int ry = Mathf.RoundToInt(cube.Y);
            int rz = Mathf.RoundToInt(cube.Z);

            // Apply x+y+z = 0 constraint
            var xdiff = Mathf.Abs(rx - cube.X);
            var ydiff = Mathf.Abs(ry - cube.Y);
            var zdiff = Mathf.Abs(rz - cube.Z);

            if (xdiff > ydiff && xdiff > zdiff)
            {
                rx = -ry - rz;
            }
            else if (ydiff > zdiff)
            {
                ry = -rx - rz;
            }
            else
            {
                rz = -rx - ry;
            }
            return new Cube(rx, ry, rz);
        }

        private static Hex HexRound(Hex hex)
        {
            return CubeToAxial(CubeRound(AxialToCube(hex)));
        }

        private static Hex CubeToAxial(Cube cube)
        {
            var q = cube.X;
            var r = cube.Z;
            return new Hex(q, r);
        }

        public static Cube AxialToCube(Hex hex)
        {
            var x = hex.Q;
            var z = hex.R;
            var y = -x - z;
            return new Cube(x, y, z);
        }

        public static Vector3 CoordinateToPoint(Coordinate coordinate)
        {
            var x = Mathf.Sqrt(3) * coordinate._hex.Q + Mathf.Sqrt(3) / 2 * coordinate._hex.R;
            var z = 3f / 2 * coordinate._hex.R;
            return new Vector3(x, 0, z);
        }

        public static Coordinate PointToCoordinate(Vector3 point)
        {
            var q = Mathf.Sqrt(3) / 3 * point.x - 1f / 3 * point.z;
            var r = 2f / 3 * point.z;
            Hex roundedHex = HexRound(new Hex(q, r));
            return new Coordinate(roundedHex);
        }
    }
}