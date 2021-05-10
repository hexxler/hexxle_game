using UnityEngine;
using UnityEngine.InputSystem;
using Hexxle.Unity.Util;
using Hexxle.CoordinateSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hexxle.Unity.Input
{
    public class MouseEventsHandler : MonoBehaviour
    {
        private GameObject oldTile;
        private GameObject currentCollisionTile;
        private InputManager inputManager;
        private bool isMouseOverTile;
        private List<GameObject> highlightedTiles;

        private GraphicRaycaster graphicsRaycaster;
        private PointerEventData pointerEventData;

        private void Awake()
        {
            oldTile = null;
            currentCollisionTile = null;
            inputManager = new InputManager();

            graphicsRaycaster = GameObjectFinder.UICanvas.GetComponent<GraphicRaycaster>();
            pointerEventData = new PointerEventData(EventSystem.current);
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

                pointerEventData.position = vec;
                List<RaycastResult> reults = new List<RaycastResult>();
                graphicsRaycaster.Raycast(pointerEventData, reults);

                // If reults contains elements, it means that there's UI between the game field and the mouse
                if (Physics.Raycast(ray, out RaycastHit hit) && reults.Count == 0)
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
            SetPossibleScoreChange();
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
                highlightedTiles.ForEach(tile => tile.transform.GetChild(0).gameObject.GetComponent<UnityTileHighlighter>().enabled = state);
            }
        }

        private void SetPossibleScoreChange()
        {
            if(currentCollisionTile != null)
            {
                var unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                GameObjectFinder.UnityMap.ShowPossibleScoreForCoordinate(coordinate);
            }
        }

        public void UpdateTiles()
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
            if (isMouseOverTile && currentCollisionTile != null && currentCollisionTile.CompareTag("Void"))
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
