using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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
        private bool stackChanged = true;

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
            if (stackChanged)
            {
                RemoveOldStack();
                DisplayStack();
            }
        }

        public ITile GetTopTile()
        {
            stackChanged = true;
            return tileStack.Pop();
        }

        public ITile Peek()
        {
            return tileStack.Peek();
        }

        public int Count()
        {
            return tileStack.Count();
        }

        public void AddNewRandomTiles(int amount)
        {
            stackChanged = true;
            tileStack.AddNewRandomTiles(amount);
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
                newTile.GetComponentInChildren<TMP_Text>().text = tile.Nature.Nature.ToString().Substring(0,2) +  "|" + tile.Behaviour.Behaviour.ToString().Substring(0,4);
            }
            stackChanged = false;
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