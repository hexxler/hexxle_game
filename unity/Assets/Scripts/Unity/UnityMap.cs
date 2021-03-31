using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using UnityEngine;

namespace Hexxle.Unity
{
    public class UnityMap : MonoBehaviour
    {
        ITileMap<ITile> map;
        ITileResolver<ITile> resolver;

        public GameObject RedTemplate;
        public GameObject GreenTemplate;
        public GameObject BlueTemplate;
        public GameObject VoidTemplate;
        public float OuterTileRadius;
        private UnityStack unityStack;

        private void Awake()
        {
            map = new TileMap();
            resolver = new TileResolver(map);
            map.TilePlaced += OnTilePlaced;
        }

        private void Start()
        {
            unityStack = GameObject.Find("Game").GetComponent("UnityStack") as UnityStack;
            Coordinate start = new Coordinate();
            PlaceRandomTile(start);
        }

        private void Update()
        {
       /*     if (Input.GetMouseButtonDown(0))
            {
                if (unityStack.Count() != 0)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        GameObject clickedTile = hit.collider.gameObject;

                        Coordinate coordinate = PointToCoordinate(clickedTile.transform.position);
                        PlaceNextTile(coordinate);

                        GameObject.Destroy(clickedTile);
                    }
                }
            }*/
        }

        private void PlaceRandomTile(Coordinate coordinate)
        {
            EType randomType = (EType)Random.Range(2, System.Enum.GetValues(typeof(EType)).Length); // None, Void < 2
            ITile tileToPlace = Tile.CreateInstance(EState.OnField, randomType, ENature.Circle, EBehaviour.NoEffect);
            // Place tile
            map.PlaceTile(
                tileToPlace,
                coordinate
                );
            PlaceVoidNeighbours(coordinate);

            // Resolve tile
            int pointsEarned = resolver.CalculatePoints(tileToPlace);
            resolver.ApplyBehaviour(tileToPlace);
        }

        private void PlaceNextTile(Coordinate coordinate)
        {
            // Needs to get top Tile from Stack
            ITile topTile = unityStack.GetTopTile();
            map.PlaceTile(topTile, coordinate);
            PlaceVoidNeighbours(coordinate);

            // Resolve tile
            int pointsEarned = resolver.CalculatePoints(topTile);
            resolver.ApplyBehaviour(topTile);
        }

        private void PlaceVoidTile(Coordinate coordinate)
        {
            map.PlaceTile(
                Tile.CreateInstance(EState.OnField, EType.Void, ENature.None, EBehaviour.None),
                coordinate)
                ;
        }

        private void PlaceVoidNeighbours(Coordinate middleCoordinate)
        {
            map.GetTile(middleCoordinate).Nature.AdjacentCoordinates(middleCoordinate).ForEach(neighboringCoordinate =>
            {
                if (map.IsEmpty(neighboringCoordinate))
                {
                    PlaceVoidTile(neighboringCoordinate);
                }
            });
        }

        private Coordinate PointToCoordinate(Vector3 point)
        {
            int x = (int)Mathf.Round((Mathf.Sqrt(3f) / 3f * point.x - (point.z / 3f)) / OuterTileRadius);
            int y = (int)Mathf.Round(-(Mathf.Sqrt(3f) / 3f * point.x + (point.z / 3f)) / OuterTileRadius);
            int z = (int)(2f / 3f * point.z / OuterTileRadius);
            return new Coordinate(x, y, z);
        }

        private Vector3 CoordinateToPoint(Coordinate coordinate)
        {
            // see https://stackoverflow.com/questions/2459402/hexagonal-grid-coordinates-to-pixel-coordinates
            float x = Mathf.Sqrt(3f) * OuterTileRadius * (coordinate.z / 2f + coordinate.x);
            float z = 3f / 2f * coordinate.z * OuterTileRadius;
            return new Vector3(x, 0, z);
        }

        private void OnTilePlaced(object sender, TileMapEventArgs<ITile> e)
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
                    CoordinateToPoint(tile.Coordinate),
                    Quaternion.Euler(-90, 0, 0)
                );

        }
    }
}
