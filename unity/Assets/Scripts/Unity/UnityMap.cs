using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hexxle.Unity
{
    public class UnityMap : MonoBehaviour
    {
        ITileMap<ITile> map;
        ITileResolver<ITile> resolver;
        public GameObject TileTemplate;
        public Material[] materials;
        public float OuterTileRadius = 0.5f;
        private UnityStack unityStack;
        private UnityPoints unityPoints;

        private void Awake()
        {
            map = new TileMap();
            resolver = new TileResolver(map);
            map.TilePlaced += OnTilePlaced;
        }


        private void Start()
        {
            unityStack = GameObject.FindGameObjectWithTag("Stack").GetComponent<UnityStack>();
            unityPoints = GameObject.FindGameObjectWithTag("Points").GetComponent<UnityPoints>();
            Coordinate start = new Coordinate();
            PlaceRandomTile(start);
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
            unityPoints.IncreasePoints(pointsEarned);
            resolver.ApplyBehaviour(tileToPlace);
        }

        public void PlaceNextTile(Coordinate coordinate)
        {
            // Needs to get top Tile from Stack
            ITile topTile = unityStack.GetTopTile();
            map.PlaceTile(topTile, coordinate);
            PlaceVoidNeighbours(coordinate);

            // Resolve tile
            int pointsEarned = resolver.CalculatePoints(topTile);
            unityPoints.IncreasePoints(pointsEarned);
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

        public Coordinate PointToCoordinate(Vector3 point)
        {
            // Modify point by OuterTileRadius
            var p = point / OuterTileRadius;
            return Coordinate.PointToCoordinate(p);
        }

        public Vector3 CoordinateToPoint(Coordinate coordinate)
        {
            var p = Coordinate.CoordinateToPoint(coordinate);
            // Modify point by OuterTileRadius
            p *= OuterTileRadius;
            return p;
        }

        public void OnTilePlaced(object sender, TileMapEventArgs<ITile> e)
        {
            ITile tile = e.Tile;
            GameObject template = TileTemplate;
            Material material;
            material = materials[(int)e.Tile.Type.Type];
            template.GetComponent<MeshRenderer>().material = material;
            if (tile.Type.Type.Equals(EType.Void))
            {
                template.GetComponent<MeshCollider>().enabled = true;
            }
            var newTile = Instantiate(
                    template,
                    CoordinateToPoint(tile.Coordinate),
                    Quaternion.Euler(-90, 0, 0)
                );
            newTile.transform.parent = this.transform;
        }
    }
}