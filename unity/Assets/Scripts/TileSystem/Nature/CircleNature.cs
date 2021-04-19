using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System.Collections.Generic;

namespace Hexxle.TileSystem.Nature
{
    public class CircleNature : BaseTileNature
    {
        public override ENature Nature => ENature.Circle;

        public override List<Coordinate> RelevantCoordinates(Coordinate coordinate)
        {
            return AdjacentCoordinates(coordinate);
        }
    }
}
