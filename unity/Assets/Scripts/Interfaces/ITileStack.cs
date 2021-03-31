using System.Collections.Generic;

namespace Hexxle.Interfaces
{
    public interface ITileStack
    {
        void InitializeStack();

        // Pushes given Tiles to the top of the stack, 1st Element in given List is added first to the stack 
        void PushTiles(List<ITile> tiles);

        // Pushes a new Tile
        void Push(ITile newTile);

        // Pops the top ITile
        ITile Pop();

        int Count();

        ITile Peek();

        List<ITile> GetFirstTenTiles();
    }
}