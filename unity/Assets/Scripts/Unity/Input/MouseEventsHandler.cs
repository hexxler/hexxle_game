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
        public bool isGamePaused { get; private set; } = false;

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
            if(Mouse.current != null && !isGamePaused)
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
                else
                {
                    oldTile = currentCollisionTile;
                    currentCollisionTile = null;
                    if (oldTile != null)
                    {
                        updateTiles();
                    }
                }
            }
        }

        public void PauseGame()
        {
           isGamePaused = true;
           if(currentCollisionTile != null)
           {
                currentCollisionTile.GetComponent<UnityTileHighlighter>().TurnOff();
           }
            
        }

        public void ResumeGame()
        {
            isGamePaused = false;
            if (currentCollisionTile != null)
            {
                currentCollisionTile.GetComponent<UnityTileHighlighter>().TurnOn();
            }
        }

        private void updateTiles()
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
            if(currentCollisionTile != null && currentCollisionTile.CompareTag("Void") && !isGamePaused)
            {
                UnityMap unityMap = GameObjectFinder.UnityMap;
                Coordinate coordinate = unityMap.PointToCoordinate(currentCollisionTile.transform.position);
                unityMap.PlaceNextTile(coordinate);

                GameObject.Destroy(currentCollisionTile);

                FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            }
        }
    }
}
