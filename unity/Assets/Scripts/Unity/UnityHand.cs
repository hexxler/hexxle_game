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
        public static int handSize = 5;
        public Hand logicHand;
        private UnityStack stack;
        public GameObject uiHand;
        public GameObject tileTemplate;
        public Button buttonTemplate;
        public Texture voidTexture;
        private bool changed = true;
        private List<GameObject> renderedTiles = new List<GameObject>();
        public Texture[] textures;

        // Start is called before the first frame update
        void Start()
        {
            stack = GameObject.FindGameObjectWithTag("Stack").GetComponent<UnityStack>();
            ITile[] firstTiles = new ITile[handSize];
            for (int i = 0; i < handSize; i++)
            {
                firstTiles[i] = stack.GetTopTile();
            }
            logicHand = new Hand(handSize, firstTiles);
        }

        // Update is called once per frame
        void Update()
        {
            if (changed)
            {
                changed = false;
                DeleteOldHand();
                RenderNewHand();
            }
        }

        void SelectTile(ITile tile)
        {
            changed = true;
            logicHand.SelectTile(tile);
        }

        public ITile TakeTile()
        {
            if (logicHand.IsTileSelected() && stack.Count() > 0)
            {
                changed = true;
                return logicHand.ReplaceTile(stack.GetTopTile());
            }
            else if(logicHand.IsTileSelected() && stack.Count() == 0)
            {
                changed = true;
                return logicHand.ReplaceTile(null);
            }
            return null;
        }

        private void DeleteOldHand()
        {
            foreach (GameObject tile in renderedTiles)
            {
                GameObject.Destroy(tile);
            }
        }

        private void RenderNewHand()
        {
            ITile selectedTile = logicHand.GetSelectedTile();
            List<ITile> tiles = logicHand.GetTiles();
            for (int i = 0; i < handSize; i++)
            {
                ITile tile = tiles[i];
                Texture texture = null;
                if (tile != null)
                {
                    texture = GetTextureForTileType(tile);
                }
                else
                {
                    texture = voidTexture;
                }
                GameObject newTile = Instantiate(tileTemplate);
                renderedTiles.Add(newTile);
                newTile.transform.SetParent(uiHand.transform, false);
                newTile.GetComponent<RawImage>().texture = texture;

                // Add Button to Tile
                Button button = Instantiate(buttonTemplate);
                button.GetComponent<Button>().onClick.AddListener(delegate { SelectTile(tile); });
                button.transform.SetParent(newTile.transform, false);

                // Add highlighted effect to button
                if (selectedTile == tile && selectedTile != null)
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
            return textures[(int)type];
        }

        public bool IsTileSelected()
        {
            return logicHand.IsTileSelected();
        }

        public ITile Peek()
        {
            if (logicHand != null)
            {
                return logicHand.GetSelectedTile();
            }
            else
            {
                return null;
            }
        }
    }

}

