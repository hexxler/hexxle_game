using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hexxle.Unity
{
    public class UnityTitlescreen : MonoBehaviour
    {
        public void PlayGame()
        {
            Debug.Log("play_game");
            SceneManager.LoadScene("Main");
        }

        public void QuitGame()
        {
            Debug.Log("Quit_game");
            Application.Quit();
        }
    }
}
