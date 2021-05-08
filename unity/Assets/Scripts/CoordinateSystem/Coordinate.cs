using System;
using System.Collections.Generic;
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

        public static Coordinate Mirror(Coordinate mirrorPoint, Coordinate coordinate)
        {
            Vector3 vectorMirrorFromCoordinate = new Vector3()
            {
                x = coordinate.X - mirrorPoint.X,
                y = coordinate.Y - mirrorPoint.Y,
                z = coordinate.Z - mirrorPoint.Z
            };
            Vector3 mirroredVector = -1 * vectorMirrorFromCoordinate;
            return new Coordinate(mirrorPoint.X + mirroredVector.x, mirrorPoint.Y + mirroredVector.y, mirrorPoint.Z + mirroredVector.z);
        }

        public static Coordinate RotateRight(Coordinate center, Coordinate coordinate, int rotation)
        {
            Coordinate rotatedCoordinate;
            if (rotation % 6 == 0)
            {
                rotatedCoordinate = coordinate;
            }
            else if (rotation < 0)
            {
                rotatedCoordinate = RotateLeft(center, coordinate, -1 * rotation);
            } 
            else
            {
                int actualRotation = rotation % 6;
                // if rotation is bigger than or equal to 3, mirror first, then rotate the rest
                if (actualRotation >= 3)
                {
                    Coordinate mirroredCoordinate = Mirror(center, coordinate);
                    rotatedCoordinate = RotateRight(center, mirroredCoordinate, actualRotation - 3);
                } 
                else
                {
                    Vector3 vectorCenterToCoord = new Vector3()
                    {
                        x =  coordinate.X - center.X,
                        y = coordinate.Y - center.Y,
                        z = coordinate.Z - center.Z
                    };
                    Vector3 rotatedVector;
                    // rotation is 1 or 2, rotate vector from center to coord by shifting X/Y/Z to the right
                    if (actualRotation < 2)
                    {
                        rotatedVector = new Vector3(-vectorCenterToCoord.z, -vectorCenterToCoord.x, -vectorCenterToCoord.y);
                    }
                    else
                    {
                        rotatedVector = new Vector3(vectorCenterToCoord.y, vectorCenterToCoord.z, vectorCenterToCoord.x);
                    }
                    // add rotated vector to center
                    rotatedCoordinate = new Coordinate(center.X + rotatedVector.x, center.Y + rotatedVector.y, center.Z + rotatedVector.z);
                }
            }
            return rotatedCoordinate;
        }

        public static Coordinate RotateLeft(Coordinate center, Coordinate coordinate, int rotation)
        {
            Coordinate rotatedCoordinate;
            if (rotation % 6 == 0)
            {
                rotatedCoordinate = coordinate;
            }
            else if (rotation < 0)
            {
                rotatedCoordinate = RotateRight(center, coordinate, -1 * rotation);
            }
            else
            {
                int rotationRight = 6 - (rotation % 6);
                rotatedCoordinate = RotateRight(center, coordinate, rotationRight);
            }
            return rotatedCoordinate;
        }

        public IEnumerable<Coordinate> AdjacentCoordinates()
        {
            var relevantCoordinates = new List<Coordinate>
            {
                new Coordinate(X + 1, Y - 1, Z),
                new Coordinate(X + 1, Y, Z - 1),
                new Coordinate(X, Y + 1, Z - 1),
                new Coordinate(X - 1, Y + 1, Z),
                new Coordinate(X - 1, Y, Z + 1),
                new Coordinate(X, Y - 1, Z + 1),
            };
            return relevantCoordinates;
        } 
    }
}