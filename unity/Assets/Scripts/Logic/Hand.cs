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

        public Hand(int handSize, ITile[] tiles)
        {
            HandSize = handSize;
            Slots = new List<ITile>();
            for (int i = 0; i < HandSize; i++)
            {
                Slots.Add(null);
            }
            FillHand(tiles);
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

        public void SelectTile(ITile selectedTile)
        {
            SelectedTile = selectedTile;
        }

        public List<ITile> GetTiles()
        {
            return Slots;
        }

        public bool IsTileSelected()
        {
            return SelectedTile != null;
        }

        public void FillHand(ITile[] tiles)
        {
            int counter = 0;
            for(int i = 0; i < HandSize; i++)
            {
                if(counter < tiles.Length && Slots[i] == null)
                {
                    Slots[i] = tiles[counter++];
                }
            }
        }

        public int EmptySlots()
        {
            int counter = 0;
            for(int i = 0; i < HandSize; i++)
            {
                if(Slots[i] == null)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
