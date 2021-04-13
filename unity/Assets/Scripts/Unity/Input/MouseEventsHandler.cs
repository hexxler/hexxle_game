using UnityEngine;
using UnityEngine.InputSystem;
using Hexxle.Unity.Util;
using Hexxle.CoordinateSystem;
using Hexxle.Unity.Audio;

namespace Hexxle.Unity.Input
{
    public class MouseEventsHandler : MonoBehaviour
    {
        GameObject oldTile;
        GameObject currentCollisionTile;

        private void Awake()
        {
            oldTile = null;
            currentCollisionTile = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            var inputManager = new InputManager();
            inputManager.TilePlacement.MouseClick.Enable();
            inputManager.TilePlacement.MouseClick.performed += context => MouseClickAction();
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
                    oldTile = currentCollisionTile;
                    currentCollisionTile = hit.collider.gameObject;
                }
                else
                {
                    oldTile = currentCollisionTile;
                    currentCollisionTile = null;
                }
                updateTiles();
            }
        }

        void updateTiles()
        {
            if (oldTile != null)
            {
                oldTile.GetComponent<UnityTileHighlighter>().TurnOff();
            }
            if (currentCollisionTile != null)
            {
                currentCollisionTile.GetComponent<UnityTileHighlighter>().TurnOn();
            }
        }

        private void MouseClickAction()
        {
            if(currentCollisionTile != null && currentCollisionTile.CompareTag("Void"))
            {
                UnityMap unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                Debug.Log(coordinate.x + " " + coordinate.y + " " + coordinate.z);
                unityMap.PlaceNextTile(coordinate);

                GameObject.Destroy(currentCollisionTile);

                FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            }
        }
    }
}
