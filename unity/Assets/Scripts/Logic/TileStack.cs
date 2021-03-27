using Assets.Scripts.Interfaces;
using Assets.Scripts.TileSystem;
using Hexxle.TileSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileStack 
{
    private static List<ITile> Stack;
 
    public TileStack()
    {
        Stack = new List<ITile>();
    }

    public void InitializeStack()
    {
        for (int i = 0; i < 30; i++)
        {
            Stack.Add(GenerateRandomTile()); 
        }

        Debug.Log(Stack.Count);
    }

    // Pushes given Tiles to the top of the stack, 1st Element in given List is added first to the stack 
    public void PushTiles(List<ITile> tiles)
    {
        while (tiles.Count > 0)
        {
            Stack.Add(tiles.First());
        }
    }

    // Pushes a new Tile
    public void Push(ITile newTile)
    {
        Stack.Add(newTile);
    }

    // Pops the top ITile
    public ITile Pop()
    {
        if (Stack.Count > 0)
        {
            Debug.Log(Stack.Count);
            ITile topTile = Stack.Last();
            Debug.Log(Stack.Count);
            Stack.RemoveAt(Stack.Count - 1);
            return topTile;
        } else
        {
            throw new System.Exception("Stack is empty");
        }
    }

    public int Count()
    {
        return Stack.Count;
    }

    public ITile Peek()
    {
        return Stack.Last();
    }

    public List<ITile> GetFirstTenTiles()
    {
        List<ITile> firstTen = new List<ITile>();
        for (int i = 10; i > 0; i--)
        {
            firstTen.Add(Stack.ElementAt(Stack.Count - i));
        }
        return firstTen;
    }

    // Generates a new Random Tile
    private ITile GenerateRandomTile()
    {
        EType randomType = (EType)Random.Range(2, System.Enum.GetValues(typeof(EType)).Length); // None, Void < 2
        ITile randomTile = Tile.CreateInstance(EState.OnField, randomType, ENature.Circle, EBehaviour.NoEffect);
        return randomTile;
    }
}
