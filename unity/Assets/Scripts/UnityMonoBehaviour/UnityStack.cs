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
    private TileStack tileStack = new TileStack();

    // Start is called before the first frame update
    void Start()
    {
        tileStack.InitializeStack();
        DisplayStack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayStack()
    {

        List<ITile> firstTen = tileStack.GetFirstTenTiles();
        for(int i = 0; i < 10; i++)
        {
            ITile tile = firstTen.ElementAt(i);
            GameObject template = GetTypeOfTile(tile);
            Instantiate(
                    template,
                    new Vector3((float)-3.7, (float)(i*0.3), -4),
                    Quaternion.Euler(-90, 0, 0)
                );
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
