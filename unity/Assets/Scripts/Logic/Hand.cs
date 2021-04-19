using Hexxle.Interfaces;
using Hexxle.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.Logic
{
    public class Hand
    {
        private List<ITile> Slots;
        private int HandSize;
        private ITile SelectedTile = null;

        public Hand(int handSize)
        {
            Slots = new List<ITile>();
            HandSize = handSize;
            Initialize();
        }

        private void Initialize()
        {
            for(int i = 0; i < HandSize; i++)
            {
                Slots.Add(null);
            }
        }

        public void Fill(ITile[] tiles)
        {
            for(int i = 0; i < HandSize; i++)
            {
                Slots[i] = tiles[i];
            }
        }

        public ITile ReplaceTile(ITile newTile)
        {
            if(SelectedTile != null)
            {
                ITile oldTile = SelectedTile;
                SelectedTile = newTile;
                Slots[Slots.FindIndex(slot => slot == oldTile)] = newTile;
                return oldTile;
            }
            throw new System.Exception("No tile in hand selected!");
        }

        public void SelectTile(ITile tile)
        {
            if(tile != null)
            {
                foreach (ITile tileHand in Slots)
                {
                    if (tileHand == tile)
                    {
                        SelectedTile = tileHand;
                        break;
                    }
                }
            }
            else
            {
                SelectedTile = null;
            }
        }

        public List<ITile> GetTiles()
        {
            return Slots;
        }

        public bool IsTileSelected()
        {
            return SelectedTile != null;
        }

    }
}
