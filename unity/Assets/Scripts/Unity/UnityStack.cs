using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hexxle.Unity
{
    public class UnityStack : MonoBehaviour
    {
        public GameObject RedTemplate;
        public GameObject GreenTemplate;
        public GameObject BlueTemplate;
        private List<GameObject> toDelete = new List<GameObject>();
        private ITileStack tileStack;
        private int stackCount = 0;

        // Start is called before the first frame update
        void Start()
        {
            tileStack = new TileStack();
            tileStack.InitializeStack();
            DisplayStack();
        }

        // Update is called once per frame
        void Update()
        {
            if (stackCount != tileStack.Count())
            {
                RemoveOldStack();
                DisplayStack();
            }
        }

        public ITile GetTopTile()
        {
            return tileStack.Pop();
        }

        public int Count()
        {
            return tileStack.Count();
        }

        private void DisplayStack()
        {

            List<ITile> firstTen = tileStack.GetFirstTenTiles();
            toDelete = new List<GameObject>();

            for (int i = 0; i < firstTen.Count; i++)
            {
                ITile tile = firstTen.ElementAt(i);
                GameObject template = GetTypeOfTile(tile);
                GameObject newTile = Instantiate(
                        template,
                        new Vector3((float)-3.7, (float)(i * 0.3), -4),
                        Quaternion.Euler(-90, 0, 0)
                    );
                toDelete.Add(newTile);
            }
            stackCount = tileStack.Count();
        }

        private void RemoveOldStack()
        {
            foreach (GameObject oldTile in toDelete)
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
}