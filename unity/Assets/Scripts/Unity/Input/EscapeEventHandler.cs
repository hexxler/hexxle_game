using Hexxle.Unity.Util;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hexxle.Unity.Audio;

namespace Hexxle.Unity.Input
{
    public class EscapeEventHandler : MonoBehaviour
    {
        // Start is called before the first frame update

        InputManager inputManager;

        private void Awake()
        {
            inputManager = new InputManager();
        }

        private void OnEnable()
        {
            inputManager.MenuInteraction.Pause.Enable();
            inputManager.MenuInteraction.Pause.performed += PauseOrUnpause;
        }

        private void OnDisable()
        {
            inputManager.MenuInteraction.Pause.Disable();
            inputManager.MenuInteraction.Pause.performed -= PauseOrUnpause;
        }

        private void PauseOrUnpause(InputAction.CallbackContext context)
        {
            // activate pausePanel if game is paused, deactivate if unpaused
            // deactivate buttons if game is paused, activate if unpaused
            var pausePanel = GameObjectFinder.PausePanel;
            bool isPaused = pausePanel.activeSelf;

            if (SceneManager.GetActiveScene().name.Equals("Main") && !GameObjectFinder.GameOverPanel.activeSelf)
            {
                // activate/deactivate PausePanel
                GameObjectFinder.PausePanel.SetActive(!isPaused);
                GameObjectFinder.MouseEventLogic.enabled = isPaused;

                // play soundeffect if PausePanel is activated
                if (!isPaused)
                {
                    FindObjectOfType<AudioManager>().Play(GameSoundTypes.PAUSE);
                }
            }
        }
    }
}

