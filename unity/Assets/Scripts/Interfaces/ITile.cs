using Hexxle.TileSystem;
using Hexxle.CoordinateSystem;

namespace Hexxle.Interfaces
{
    public interface ITile
    {
        #region Data
        Coordinate Coordinate { get; set; }
        EState State { get; set; }
        ITileType Type { get; set; }
        ITileBehaviour Behaviour { get; set; }
        ITileNature Nature { get; set; }
        #endregion
    }
}
