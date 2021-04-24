using UnityEngine;
using UnityEngine.InputSystem;
using Hexxle.Unity.Util;
using Hexxle.CoordinateSystem;

namespace Hexxle.Unity.Input
{
    public class MouseEventsHandler : MonoBehaviour
    {
        GameObject oldTile;
        GameObject currentCollisionTile;
        InputManager inputManager;

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
                        updateTiles();
                    }
                }
            }
        }

        private void updateTiles()
        {
            if (oldTile != null)
            {
                oldTile.GetComponent<UnityTileHighlighter>().enabled = false;
            }
            if (currentCollisionTile != null)
            {
                UnityMap unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                unityMap.ShowPossibleScoreForCoordinate(coordinate);
                currentCollisionTile.GetComponent<UnityTileHighlighter>().enabled = true;
            }
        }

        private void MouseClickAction()
        {
            if(currentCollisionTile != null && currentCollisionTile.CompareTag("Void"))
            {
                UnityMap unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                unityMap.PlaceNextTile(coordinate, currentCollisionTile);
            }
        }
    }
}
