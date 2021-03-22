using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hexxle.CoordinateSystem;
using Hexxle.ClassSystem;


public class Game : MonoBehaviour
{
    Hexagonal<GameObject> map = new Hexagonal<GameObject>();

    public GameObject TileTemplate;

    // Start is called before the first frame update
    void Start()
    {
        NewTemplate(new Coordinate());
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void NewTemplate(Coordinate coordinate)
    {
        map[coordinate] = Instantiate(
                TileTemplate,
                new Vector3(0, 0, 0),
                Quaternion.Euler(-90, 0, 0)
            );
    }
}
