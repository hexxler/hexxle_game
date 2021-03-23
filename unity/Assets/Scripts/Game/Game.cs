using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hexxle.CoordinateSystem;
using Hexxle.ClassSystem;


public class Game : MonoBehaviour
{
    HexagonalMap map;

    public GameObject VoidTile;

    // Start is called before the first frame update
    void Start()
    {
        map = new HexagonalMap();
        SetMiddleTile(new Coordinate());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void AddVoidTilesAroundCoordinate(Coordinate coordinate)
    {

    }

    void SetMiddleTile(Coordinate coordinate)
    {
        map[coordinate] = new Tile(Breed.Void);
        DisplayNewTile(coordinate);
    }


    void DisplayNewTile(Coordinate coordinate)
    {
        Instantiate(
            VoidTile,
            new Vector3(coordinate.x, coordinate.y, coordinate.z),
            Quaternion.Euler(-90, 0, 0)
            );
    }
}
