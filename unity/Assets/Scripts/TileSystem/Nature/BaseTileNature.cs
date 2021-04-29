using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.TileSystem.Nature
{
    public abstract class BaseTileNature : ITileNature
    {
        public abstract ENature Nature { get; }

        public abstract int CalculateWeight();
        public abstract IEnumerable<Coordinate> RelevantCoordinates(Coordinate coordinate);
    }
}
