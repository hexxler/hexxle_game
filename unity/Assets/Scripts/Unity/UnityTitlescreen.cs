using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hexxle.Unity
{
    public class UnityTitlescreen : MonoBehaviour
    {
        public void PlayGame()
        {
            Debug.Log("play_game");
            //play soundeffect
            FindObjectOfType<AudioManager>().PlayRandomPop();

            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Debug.Log("Quit_game");
            //play soundeffect
            FindObjectOfType<AudioManager>().PlayRandomPop();

            Application.Quit();
        }
    }
}
