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
            FindObjectOfType<AudioManager>().Play("pop");

            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Debug.Log("Quit_game");
            //play soundeffect
            FindObjectOfType<AudioManager>().Play("pop");

            Application.Quit();
        }
    }
}
