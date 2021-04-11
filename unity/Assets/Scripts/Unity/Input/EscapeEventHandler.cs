using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeEventHandler : MonoBehaviour
{
    // Start is called before the first frame update

    InputManager inputManager;

    private void Awake()
    {
        inputManager = new InputManager();
        inputManager.MenuInteraction.Pause.Enable();
        inputManager.MenuInteraction.Pause.performed += context => ReturnToMainMenu();
    }
   
    private void ReturnToMainMenu()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.Equals("Main"))
        {
            // activate pausePanel if game is paused, deactivate if unpaused
            // deactivate buttons if game is paused, activate if unpaused
            var pausePanel = GameObjectFinder.PausePanel;
            bool isPaused = pausePanel.activeSelf;
            // activate/deactivate PausePanel
            GameObjectFinder.PausePanel.SetActive(!isPaused);

            // enable/disable Buttons in UI
            foreach (Button button in GameObjectFinder.UIPanel.GetComponentsInChildren<Button>())
            {
                button.enabled = isPaused;
            }
        }
    }
}
