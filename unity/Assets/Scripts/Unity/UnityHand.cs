using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hexxle.Unity
{
    public class UnityHand : MonoBehaviour
    {
        public static int HandSize = 5;
        public Hand LogicHand = new Hand(HandSize);
        private UnityStack Stack;
        public GameObject UIHand;
        public GameObject Template;
        private bool Changed = true;
        private List<GameObject> RenderedTiles = new List<GameObject>();
        public Texture[] Textures;

        // Start is called before the first frame update
        void Start()
        {
            Stack = GameObject.FindGameObjectWithTag("Stack").GetComponent<UnityStack>();
            LogicHand.Fill(Initialize());
        }

        // Update is called once per frame
        void Update()
        {
            if (Changed)
            {
                Changed = false;
                DeleteOldHand();
                RenderNewHand();
            }
        }

        public ITile[] Initialize()
        {
            ITile[] firstTiles = new ITile[HandSize];
            for(int i=0; i < HandSize; i++)
            {
                firstTiles[i] = Stack.GetTopTile();
            }
            return firstTiles;
        }

        public ITile PlaceTile()
        {
            Changed = true;
            return LogicHand.ReplaceTile(Stack.GetTopTile());
        }

        public void Select(TileHand tile)
        {
            Changed = true;
            LogicHand.SelectTile(tile);
        }

        private void DeleteOldHand()
        {
            foreach (GameObject tile in RenderedTiles)
            {
                GameObject.Destroy(tile);
            }
        }

        private void RenderNewHand()
        {
            List<ITile> tiles = LogicHand.GetTiles();
            for (int i = 0; i < HandSize; i++)
            {
                ITile tile = tiles[i];
                Texture texture = GetTextureForTileType(tile);
                GameObject newTile = Instantiate(Template);
                RenderedTiles.Add(newTile);
                newTile.transform.SetParent(UIHand.transform, false);
                newTile.GetComponent<RawImage>().texture = texture;
            }
        }

        private Texture GetTextureForTileType(ITile tile)
        {
            EType type = tile.Type.Type;
            return Textures[(int)type];
        }
    }

}

