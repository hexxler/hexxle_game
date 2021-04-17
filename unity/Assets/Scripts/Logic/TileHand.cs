using Hexxle.Interfaces;
using Hexxle.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.Logic
{
    public class TileHand
    {
        private ITile Tile = null;

        public ITile GetTile()
        {
            return Tile;
        }

        public void SetTile(ITile tile)
        {
            Tile = tile;
        }

    }
}
