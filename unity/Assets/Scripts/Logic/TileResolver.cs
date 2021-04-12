using Hexxle.Interfaces;
using System.Linq;

namespace Hexxle.Logic
{
    public class TileResolver : ITileResolver<ITile>
    {
        ITileMap<ITile> _map;
        public TileResolver(ITileMap<ITile> map)
        {
            _map = map;
        }
        public void ApplyBehaviour(ITile tile)
        {
            tile.Nature.RelevantCoordinates(tile.Coordinate)
                .ForEach(coordinate => tile.Behaviour.ApplyBehaviour(_map.GetTile(coordinate)));
        }

        public int CalculatePoints(ITile tile)
        {
            return tile.Nature.RelevantCoordinates(tile.Coordinate)
                .Sum(coordinate => tile.Type.ValueOfRelationshipTo(_map.GetTile(coordinate).Type.Type));
        }
    }
}
