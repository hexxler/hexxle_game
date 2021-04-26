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
    }
}
