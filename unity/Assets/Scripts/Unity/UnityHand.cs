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
        public Hand LogicHand;
        private UnityStack Stack;
        public GameObject UIHand;
        public GameObject TileTemplate;
        public Button ButtonTemplate;
        public Texture VoidTexture;
        private bool Changed = true;
        private List<GameObject> RenderedTiles = new List<GameObject>();
        public Texture[] Textures;

        // Start is called before the first frame update
        void Start()
        {
            Stack = GameObject.FindGameObjectWithTag("Stack").GetComponent<UnityStack>();
            ITile[] firstTiles = new ITile[HandSize];
            for (int i = 0; i < HandSize; i++)
            {
                firstTiles[i] = Stack.GetTopTile();
            }
            LogicHand = new Hand(HandSize, firstTiles);
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

        void SelectTile(ITile tile)
        {
            Changed = true;
            LogicHand.SelectTile(tile);
        }

        public ITile TakeTile()
        {
            if (LogicHand.IsTileSelected() && Stack.Count() > 0)
            {
                Changed = true;
                return LogicHand.ReplaceTile(Stack.GetTopTile());
            }
            else if(LogicHand.IsTileSelected() && Stack.Count() == 0)
            {
                Changed = true;
                return LogicHand.ReplaceTile(null);
            }
            return null;
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
            ITile selectedTile = LogicHand.GetSelectedTile();
            List<ITile> tiles = LogicHand.GetTiles();
            for (int i = 0; i < HandSize; i++)
            {
                ITile tile = tiles[i];
                Texture texture = null;
                if (tile != null)
                {
                    texture = GetTextureForTileType(tile);
                }
                else
                {
                    texture = VoidTexture;
                }
                GameObject newTile = Instantiate(TileTemplate);
                RenderedTiles.Add(newTile);
                newTile.transform.SetParent(UIHand.transform, false);
                newTile.GetComponent<RawImage>().texture = texture;

                // Add Button to Tile
                Button button = Instantiate(ButtonTemplate);
                button.GetComponent<Button>().onClick.AddListener(delegate { SelectTile(tile); });
                button.transform.SetParent(newTile.transform, false);
                if (selectedTile == tile)
                {
                    ColorBlock cb = button.colors;
                    cb.normalColor = new Color(255f, 0f, 0f, 0.1f);
                    button.colors = cb;
                }
                else
                {
                    ColorBlock cb = button.colors;
                    cb.normalColor = new Color(255f, 0f, 0f, 0f);
                    button.colors = cb;
                }
            }
        }

        private Texture GetTextureForTileType(ITile tile)
        {
            EType type = tile.Type.Type;
            return Textures[(int)type];
        }

        public bool IsTileSelected()
        {
            return LogicHand.IsTileSelected();
        }
    }

}

