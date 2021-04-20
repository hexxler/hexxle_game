using Hexxle.Interfaces;
using Hexxle.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.Logic
{
    public class Hand
    {
        private List<ITile> slots;
        private int handSize;
        private ITile selectedTile = null;

        public Hand(int handSize, ITile[] tiles)
        {
            this.handSize = handSize;
            slots = new List<ITile>();
            for (int i = 0; i < this.handSize; i++)
            {
                slots.Add(null);
            }
            FillHand(tiles);
        }

        public ITile ReplaceTile(ITile newTile)
        {
            if(selectedTile != null)
            {
                ITile oldTile = selectedTile;
                selectedTile = newTile;
                slots[slots.FindIndex(slot => slot == oldTile)] = newTile;
                return oldTile;
            }
            throw new System.Exception("No tile in hand selected!");
        }

        public void SelectTile(ITile selectedTile)
        {
            this.selectedTile = selectedTile;
        }

        public List<ITile> GetTiles()
        {
            return slots;
        }

        public bool IsTileSelected()
        {
            return selectedTile != null;
        }

        public ITile GetSelectedTile()
        {
            return selectedTile;
        }

        public void FillHand(ITile[] tiles)
        {
            int counter = 0;
            for(int i = 0; i < handSize; i++)
            {
                if(counter < tiles.Length && slots[i] == null)
                {
                    slots[i] = tiles[counter++];
                }
            }
        }

        public int EmptySlots()
        {
            int counter = 0;
            for(int i = 0; i < handSize; i++)
            {
                if(slots[i] == null)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
