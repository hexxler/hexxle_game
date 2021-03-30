using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().name.Equals("Main"))
        {
            SceneManager.LoadSceneAsync("titlescreen", LoadSceneMode.Single);
        }
    }
}
