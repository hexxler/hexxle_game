using Hexxle.Interfaces;
using Hexxle.TileSystem;
using System.Collections.Generic;
using System.Linq;

namespace Hexxle.Logic
{
    public class TileStack : ITileStack
    {
        private List<ITile> stack;
        private RandomTileGenerator tileGenerator;

        public TileStack()
        {
            stack = new List<ITile>();
            tileGenerator = new RandomTileGenerator();
        }

        public TileStack(int seed)
        {
            stack = new List<ITile>();
            tileGenerator = new RandomTileGenerator(seed);
        }

        public void InitializeStack()
        {
            for (int i = 0; i < 30; i++)
            {
                stack.Add(tileGenerator.GenerateRandomTile());
            }
        }

        // Pushes given Tiles to the top of the stack, 1st Element in given List is added first to the stack 
        public void PushTiles(List<ITile> tiles)
        {
            while (tiles.Count > 0)
            {
                stack.Add(tiles.First());
                tiles.RemoveAt(0);
            }
        }

        // Pushes a new Tile
        public void Push(ITile newTile)
        {
            stack.Insert(0,newTile);
        }

        // Pops the top ITile
        public ITile Pop()
        {
            if (stack.Count > 0)
            {
                ITile topTile = stack.Last();
                stack.RemoveAt(stack.Count - 1);
                return topTile;
            }
            else
            {
                throw new System.Exception("Stack is empty");
            }
        }

        public int Count()
        {
            return stack.Count;
        }

        public ITile Peek()
        {
            return stack.Last();
        }

        public List<ITile> GetFirstTenTiles()
        {
            List<ITile> firstTen = new List<ITile>();
            for (int i = 10; i > 0; i--)
            {
                if (stack.Count - i >= 0)
                {
                    firstTen.Add(stack.ElementAt(stack.Count - i));
                }
            }
            return firstTen;
        }

        public void AddNewRandomTiles(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                Push(tileGenerator.GenerateRandomTile());
            }
        }

    }
}