using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.Logic;
using Hexxle.TileSystem;
using UnityEngine;
using Hexxle.Unity.Audio;
using System.Linq;
using System.Collections.Generic;
using Hexxle.TileSystem.Nature;
using Hexxle.TileSystem.Behaviour;

namespace Hexxle.Unity
{
    public class UnityMap : MonoBehaviour
    {
        private Dictionary<Coordinate, GameObject> tileObjects;

        ITileMap<ITile> map;
        ITileResolver<ITile> resolver;
        public GameObject TileTemplate;
        public Material[] materials;
        public float OuterTileRadius = 0.5f;
        private UnityHand unityHand;
        private UnityPoints unityPoints;
        private UnityPossiblePoints unityPossiblePoints;

        private void Awake()
        {
            tileObjects = new Dictionary<Coordinate, GameObject>();
            map = new TileMap();
            resolver = new TileResolver(map);
            map.TilePlaced += OnTilePlaced;
            map.TileRemoved += OnTileRemoved;
        }


        private void Start()
        {
            unityHand = GameObject.FindGameObjectWithTag("Hand").GetComponent<UnityHand>();
            unityPoints = GameObject.FindGameObjectWithTag("Points").GetComponent<UnityPoints>();
            unityPossiblePoints = GameObject.FindGameObjectWithTag("Points").GetComponent<UnityPossiblePoints>();
            Coordinate start = new Coordinate();
            PlaceStartingTile(start);
        }


        private void PlaceStartingTile(Coordinate coordinate)
        {
            EType randomType = (EType)Random.Range(2, System.Enum.GetValues(typeof(EType)).Length); // None, Void < 2
            ITile tileToPlace = Tile.CreateInstance(EState.OnField, Tile.CreateType(randomType), Tile.CreateNature(ENature.None), Tile.CreateBehaviour(EBehaviour.None));
            // Place tile
            map.PlaceTile(
                tileToPlace,
                coordinate
                );
        }

        public void PlaceNextTile(Coordinate coordinate, GameObject currentCollisionTile)
        {
            if(unityHand.IsTileSelected())
            {
                // Remove old tile
                tileObjects.Remove(coordinate);
                GameObject.Destroy(currentCollisionTile);

                // Needs to get new tile from Hand
                ITile topTile = unityHand.TakeTile();
                map.PlaceTile(topTile, coordinate);

                // Resolve new tile
                int pointsEarned = resolver.CalculatePoints(topTile);
                unityPoints.IncreasePoints(pointsEarned);
                resolver.ApplyBehaviour(topTile);

                FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            }
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

        public ITile TileOnPoint(Vector3 point)
        {
            Coordinate coordinate = PointToCoordinate(point);
            return map.GetTile(coordinate);
        }

        public GameObject TileObjectOnPoint(Vector3 point)
        {
            Coordinate coordinate = PointToCoordinate(point);
            return tileObjects[coordinate];
        }

        public void OnTilePlaced(object sender, TileMapEventArgs<ITile> e)
        {
            ITile tile = e.Tile;
            var newTileObject = Instantiate(
                    TileTemplate,
                    CoordinateToPoint(tile.Coordinate),
                    Quaternion.Euler(-90, 0, 0)
                );
            newTileObject.transform.parent = this.transform;
            tileObjects.Add(tile.Coordinate, newTileObject);
        }

        public void OnTileRemoved(object sender, TileMapEventArgs<ITile> e)
        {
            ITile tile = e.Tile;

            // Remove old tile
            var tileObject = tileObjects[tile.Coordinate];
            tileObjects.Remove(tile.Coordinate);
            GameObject.Destroy(tileObject);
        }

        public void ResetGameScore()
        {
            unityPossiblePoints.possibleScore = 0;
        }

        public void ShowPossibleScoreForCoordinate(Coordinate coordinate)
        {
            if(unityHand.Peek() != null)
            {
                if (map.GetTile(coordinate).Type.Type.Equals(EType.Void))
                {
                    ITile tile = unityHand.Peek();
                    tile.Coordinate = coordinate;
                    int pointsEarned = resolver.CalculatePoints(tile);
                    unityPossiblePoints.possibleScore = pointsEarned;
                }
                else
                {
                    unityPossiblePoints.possibleScore = 0;
                }
            }
        }

        public List<GameObject> GetAffectedTiles(Coordinate coordinate)
        {
            if(unityHand.IsTileSelected())
            {
                ITile tile = unityHand.Peek();
                return tile.Nature.RelevantCoordinates(coordinate).Where(coord => tileObjects.ContainsKey(coord)).Select(coord => tileObjects[coord]).ToList();
            }
            return new List<GameObject>();
        }
    }
}