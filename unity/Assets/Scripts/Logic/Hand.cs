using Hexxle.Interfaces;
using Hexxle.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.Logic
{
    public class Hand
    {
        public List<TileHand> Slots;
        private int HandSize;
        private TileHand SelectedTile = null;

        public Hand(int handSize)
        {
            Slots = new List<TileHand>();
            HandSize = handSize;
            Initialize();
        }

        private void Initialize()
        {
            for(int i = 0; i < HandSize; i++)
            {
                Slots.Add(new TileHand());
            }
        }

        public void Fill(ITile[] tiles)
        {
            for(int i = 0; i < HandSize; i++)
            {
                Slots[i].SetTile(tiles[i]);
            }
        }

        public ITile ReplaceTile(ITile newTile)
        {
            if(SelectedTile != null)
            {
                ITile oldTile = SelectedTile.GetTile();
                SelectedTile.SetTile(newTile);
                return oldTile;
            }
            throw new System.Exception("No tile in hand selected!");
        }

        public void SelectTile(ITile tile)
        {
            foreach(TileHand tileHand in Slots)
            {
                if(tileHand.GetTile() == tile)
                {
                    SelectedTile = tileHand;
                    break;
                }
            }
        }

        public List<ITile> GetTiles()
        {
            List<ITile> tiles = new List<ITile>();
            for(int i=0; i < HandSize; i++)
            {
                tiles.Add(Slots[i].GetTile());
            }
            return tiles;
        }

        public bool IsTileSelected()
        {
            return SelectedTile != null;
        }

    }
}
