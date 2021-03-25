using Assets.Scripts.TileSystem;
using Hexxle.CoordinateSystem;

namespace Assets.Scripts.Interfaces
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
