using Assets.Scripts.Interfaces;
using Assets.Scripts.Logic;
using Assets.Scripts.TileSystem;
using Hexxle.CoordinateSystem;
using Hexxle.TileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UnityMonoBehaviour
{
    public class UnityMap : MonoBehaviour
    {
        ITileMap<Tile> map;

        public GameObject RedTemplate;
        public GameObject GreenTemplate;
        public GameObject BlueTemplate;
        public GameObject VoidTemplate;
        public float OuterTileRadius;

        private void Awake()
        {
            map = new TileMap();
            map.TilePlaced += OnTilePlaced;
        }

        private void OnTilePlaced(object sender, TileMapEventArgs<Tile> e)
        {
            ITile tile = e.Tile;
            GameObject template;
            switch (tile.Type.Type)
            {
                case EType.Red:
                    template = RedTemplate;
                    break;
                case EType.Blue:
                    template = BlueTemplate;
                    break;
                case EType.Green:
                    template = GreenTemplate;
                    break;
                case EType.Void:
                case EType.None:
                default:
                    template = VoidTemplate;
                    break;
            }
            Instantiate(
                    template,
                    TranslateToUnityCoordinates(tile.Coordinate),
                    Quaternion.Euler(-90, 0, 0)
                );
        }

        private void Start()
        {
            NewRedTile(RedTemplate, new Coordinate(0, 0, 0));
            NewBlueTile(BlueTemplate, new Coordinate(-1, 0, 1));
            NewGreenTile(GreenTemplate, new Coordinate(1, 0, -1));
        }

        private void Update()
        {
            
        }

        void NewRedTile(GameObject template, Coordinate coordinate)
        {
            map.PlaceTile(
                Tile.CreateInstance(EState.OnField, EType.Red, ENature.Circle, EBehaviour.NoEffect),
                coordinate
                );
        }

        void NewBlueTile(GameObject template, Coordinate coordinate)
        {
            map.PlaceTile(
                Tile.CreateInstance(EState.OnField, EType.Blue, ENature.Circle, EBehaviour.NoEffect), 
                coordinate
                );
        }

        void NewGreenTile(GameObject template, Coordinate coordinate)
        {
            map.PlaceTile(
                Tile.CreateInstance(EState.OnField, EType.Green, ENature.Circle, EBehaviour.NoEffect),
                coordinate
                );
        }

        private Vector3 TranslateToUnityCoordinates(Coordinate coordinate)
        {
            // see https://stackoverflow.com/questions/2459402/hexagonal-grid-coordinates-to-pixel-coordinates
            return new Vector3
            {
                x = Mathf.Sqrt(3) * OuterTileRadius * (coordinate.z / 2f + coordinate.x),
                y = 0,
                z = 3 / 2f * OuterTileRadius * coordinate.z
            };
        }
    }
}
