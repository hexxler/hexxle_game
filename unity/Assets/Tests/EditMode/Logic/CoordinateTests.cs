using Hexxle.CoordinateSystem;
using NUnit.Framework;
using UnityEngine;

namespace Hexxle.Tests.Logic
{
    public class CoordinateTests
    {
        [Test]
        public void Conversion_Hexxle91()
        {
            float outerTileRadius = 0.57f;

            Coordinate expected1 = new Coordinate(-9, -9, 18);
            Coordinate expected2 = new Coordinate(-10, -9, 19);

            var testPoint1 = Coordinate.CoordinateToPoint(expected1) * outerTileRadius;
            var testPoint2 = Coordinate.CoordinateToPoint(expected2) * outerTileRadius;

            var actualConversion1 = Coordinate.PointToCoordinate(testPoint1 / outerTileRadius);
            var actualConversion2 = Coordinate.PointToCoordinate(testPoint2 / outerTileRadius);

            Assert.AreEqual(expected1, actualConversion1);
            Assert.AreEqual(expected2, actualConversion2);
        }

        [Test]
        public void PointToCoordinate_Hexxle91()
        {
            float outerTileRadius = 0.57f;

            Vector3 point1 = new Vector3(0.0f, 0.0f, 15.4f);
            Vector3 point2 = new Vector3(-0.5f, 0.0f, 16.2f);

            var testCoord1 = Coordinate.PointToCoordinate(point1 / outerTileRadius);
            var testCoord2 = Coordinate.PointToCoordinate(point2 / outerTileRadius);

            Assert.AreNotEqual(testCoord1, testCoord2);
        }

        [Test]
        public void MirroredCoordinate_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(-1, 4, -3);
            Coordinate expected = new Coordinate(1, -4, 3);

            var actual = Coordinate.Mirror(center, original);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MirroredCoordinate()
        {
            Coordinate center = new Coordinate(-2, -1, 3);
            Coordinate original = new Coordinate(-2, -2, 4);
            Coordinate expected = new Coordinate(-2, 0, 2);

            var actual = Coordinate.Mirror(center, original);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rotate_Zero()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(0, -5, 5);
            Coordinate expected = original;

            var actual1 = Coordinate.RotateRight(center, original, 0);
            var actual2 = Coordinate.RotateLeft(center, original, 0);
            var actual3 = Coordinate.RotateRight(center, original, 6);
            var actual4 = Coordinate.RotateLeft(center, original, 6);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void RotateRight_Once_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(0, 5, -5);
            Coordinate expected = new Coordinate(5, 0, -5);

            var actual1 = Coordinate.RotateRight(center, original, 1);
            var actual2 = Coordinate.RotateRight(center, original, 7);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void RotateLeft_Once_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(5, 0, -5);
            Coordinate expected = new Coordinate(0, 5, -5);

            var actual1 = Coordinate.RotateLeft(center, original, 1);
            var actual2 = Coordinate.RotateLeft(center, original, 7);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void RotateRight_Twice_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(0, 5, -5);
            Coordinate expected = new Coordinate(5, -5, 0);

            var actual1 = Coordinate.RotateRight(center, original, 2);
            var actual2 = Coordinate.RotateRight(center, original, 8);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void RotateLeft_Twice_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(5, -5, 0);
            Coordinate expected = new Coordinate(0, 5, -5);

            var actual1 = Coordinate.RotateLeft(center, original, 2);
            var actual2 = Coordinate.RotateLeft(center, original, 8);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void RotateRight_ThreeTimes_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(0, -5, 5);
            Coordinate expected = new Coordinate(0, 5, -5);

            var actual1 = Coordinate.RotateRight(center, original, 3);
            var actual2 = Coordinate.RotateRight(center, original, 9);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void RotateLeft_ThreeTimes_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(5, -5, 0);
            Coordinate expected = new Coordinate(-5, 5, 0);

            var actual1 = Coordinate.RotateLeft(center, original, 3);
            var actual2 = Coordinate.RotateLeft(center, original, 9);

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void Rotate_MoreThanThree_Origin()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(0, 5, -5);
            Coordinate expected1 = new Coordinate(-5, 0, 5);
            Coordinate expected2 = new Coordinate(-5, 5, 0);

            var actual1 = Coordinate.RotateRight(center, original, 4);
            var actual2 = Coordinate.RotateRight(center, original, 5);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [Test]
        public void Rotate_RightLeft_Equality()
        {
            Coordinate center = new Coordinate(0, 0, 0);
            Coordinate original = new Coordinate(0, 5, -5);

            for (int i = 0; i < 6; i++)
            {
                var rightRotation = Coordinate.RotateRight(center, original, i);
                var leftRotation = Coordinate.RotateLeft(center, original, 6 - i);
                Assert.AreEqual(rightRotation, leftRotation);
            }
        }
    }
}
