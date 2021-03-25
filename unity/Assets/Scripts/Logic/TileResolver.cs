using Assets.Scripts.Interfaces;
using Hexxle.TileSystem;
using System.Linq;

namespace Assets.Scripts.Logic
{
    public class TileResolver<T> : ITileResolver<T> where T : class, ITile, new()
    {
        ITileMap<Tile> _map;
        public TileResolver(TileMap map)
        {
            _map = map;
        }
        public void ApplyBehaviour(T tile)
        {
            tile.Nature.RelevantCoordinates(tile.Coordinate)
                .ForEach(coordinate => tile.Behaviour.ApplyBehaviour(_map.GetTile(coordinate)));
        }

        public int CalculatePoints(T tile)
        {
            return tile.Nature.RelevantCoordinates(tile.Coordinate)
                .Sum(coordinate => tile.Type.ValueOfRelationshipTo(_map.GetTile(coordinate).Type.Type));
        }
    }
}
