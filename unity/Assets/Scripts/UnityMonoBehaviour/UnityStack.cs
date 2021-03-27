using Assets.Scripts.Interfaces;
using Hexxle.TileSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnityStack : MonoBehaviour
{ 
    public GameObject RedTemplate;
    public GameObject GreenTemplate;
    public GameObject BlueTemplate;
    private List<GameObject> toDelete = new List<GameObject>();
    private int stackCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        TileStack.InitializeStack();
        DisplayStack();
    }

    // Update is called once per frame
    void Update()
    {
        if (stackCount != TileStack.Count())
        {
            RemoveOldStack();
            DisplayStack();
        }
    }

    private void DisplayStack()
    {

        List<ITile> firstTen = TileStack.GetFirstTenTiles();
        toDelete = new List<GameObject>();
        
        for(int i = 0; i < firstTen.Count; i++)
        {
            ITile tile = firstTen.ElementAt(i);
            GameObject template = GetTypeOfTile(tile);
            GameObject newTile = Instantiate(
                    template,
                    new Vector3((float)-3.7, (float)(i*0.3), -4),
                    Quaternion.Euler(-90, 0, 0)
                );
            toDelete.Add(newTile);
        }
        stackCount = TileStack.Count();
    }

    private void RemoveOldStack()
    {
        foreach(GameObject oldTile in toDelete)
        {
            GameObject.Destroy(oldTile);
        }
    }

    private GameObject GetTypeOfTile(ITile tile)
    {
        switch (tile.Type.Type)
        {
            case EType.Red:
                return RedTemplate;
            case EType.Blue:
                return BlueTemplate;
            case EType.Green:
                return GreenTemplate;
            default:
                return null;
        }
    }
}
