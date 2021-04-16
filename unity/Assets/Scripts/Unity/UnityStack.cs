using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Hexxle.Unity
{
    public class UnityStack : MonoBehaviour
    {
        public GameObject Template;
        public Texture[] Textures;
        public GameObject Content;
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

            for (int i = firstTen.Count -1; i >= 0; i--)
            {
                ITile tile = firstTen.ElementAt(i);
                Texture texture = GetTextureForTileType(tile);
                GameObject newTile = Instantiate(Template);
                toDelete.Add(newTile);
                newTile.transform.SetParent(Content.transform, false);
                newTile.GetComponent<RawImage>().texture = texture;
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

        private Texture GetTextureForTileType(ITile tile)
        {
            EType type = tile.Type.Type;
            return Textures[(int)type];
        }
    }
}