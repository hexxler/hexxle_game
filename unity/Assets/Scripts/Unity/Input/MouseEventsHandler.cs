using UnityEngine;
using UnityEngine.InputSystem;
using Hexxle.Unity.Util;
using Hexxle.CoordinateSystem;
using System.Collections.Generic;

namespace Hexxle.Unity.Input
{
    public class MouseEventsHandler : MonoBehaviour
    {
        GameObject oldTile;
        GameObject currentCollisionTile;
        InputManager inputManager;
        private bool isMouseOverTile;
        List<GameObject> highlightedTiles;

        private void Awake()
        {
            oldTile = null;
            currentCollisionTile = null;
            inputManager = new InputManager();
        }


        private void OnEnable()
        {
            inputManager.TilePlacement.MouseClick.Enable();
            inputManager.TilePlacement.MouseClick.performed += _ => MouseClickAction();
            if (currentCollisionTile != null)
            {
                currentCollisionTile.GetComponent<UnityTileHighlighter>().enabled = true;
            }
        }

        private void OnDisable()
        {
            inputManager.TilePlacement.MouseClick.Disable();
            inputManager.TilePlacement.MouseClick.performed -= context => MouseClickAction();
            if (currentCollisionTile != null)
            {
                currentCollisionTile.GetComponent<UnityTileHighlighter>().enabled = false;
            }

        }

        // Update is called once per frame
        void Update()
        {   
            if(Mouse.current != null)
            {
                var vec = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(vec.x, vec.y, 0));
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (!hit.collider.gameObject.Equals(currentCollisionTile))
                    {
                        oldTile = currentCollisionTile;
                        currentCollisionTile = hit.collider.gameObject;
                        UpdateTiles();
                    }
                    isMouseOverTile = true;
                }
                else
                {
                    GameObjectFinder.UnityMap.ResetGameScore();
                    isMouseOverTile = false;
                    oldTile = currentCollisionTile;
                    currentCollisionTile = null;
                    UpdateTiles();
                }
            }
        }

        private void SetHighlightedTiles()
        {
            SetHighlightedTilesState(false);
            UpdateHighlightedTiles();
            SetHighlightedTilesState(true);

        }

        private void UpdateHighlightedTiles()
        {
            if(currentCollisionTile != null)
            {
                var unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                highlightedTiles = unityMap.GetAffectedTiles(coordinate);
            }
        }

        private void SetHighlightedTilesState(bool state)
        {
            if(highlightedTiles != null)
            {
                highlightedTiles.ForEach(tile => tile.GetComponent<UnityTileHighlighter>().enabled = state);
            }
        }

        private void UpdateTiles()
        {
            UpdateOldTile();
            SetHighlightedTiles();
            UpdateCurrentTile();
        }

        private void UpdateOldTile()
        {
            if (oldTile != null)
            {
                oldTile.GetComponent<UnityTileHighlighter>().enabled = false;
            }
        }

        private void UpdateCurrentTile()
        {
            if (currentCollisionTile != null)
            {
               currentCollisionTile.GetComponent<UnityTileHighlighter>().enabled = true;
            }
        }

        private void MouseClickAction()
        {
            if(isMouseOverTile && currentCollisionTile != null && currentCollisionTile.CompareTag("Void"))
            {
                UnityMap unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                var tileToReplace = oldTile = currentCollisionTile;
                currentCollisionTile = null;
                SetHighlightedTilesState(false);
                unityMap.PlaceNextTile(coordinate, tileToReplace);
            }
        }
    }
}
