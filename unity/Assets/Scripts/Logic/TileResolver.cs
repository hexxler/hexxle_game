using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using System.Collections.Generic;
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
            IEnumerable<Coordinate> relevantCoordinates = tile.Nature.RelevantCoordinates(tile.Coordinate, tile.Rotation);
            foreach (Coordinate coordinate in relevantCoordinates)
            {
                var otherTile = _map.GetTile(coordinate);
                if (otherTile is ITile)
                {
                    tile.Behaviour.ApplyBehaviour(tile, _map.GetTile(coordinate));
                }
            }
        }

        public int CalculatePoints(ITile tile)
        {
            return tile.Nature.RelevantCoordinates(tile.Coordinate, tile.Rotation)
                .Sum(coordinate => {
                    int points = 0;
                    var otherTile = _map.GetTile(coordinate);
                    if (otherTile is ITile)
                    {
                        points = tile.Type.ValueOfRelationshipTo(otherTile.Type.Type);
                    }
                    return points; 
                });
        }
    }
}
