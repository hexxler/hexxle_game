using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hexxle.Unity
{
    public class UnityTitlescreen : MonoBehaviour
    {

        void Start()
        {
            transform.GetChild(2).gameObject.SetActive(false); // InfoPanel
            transform.GetChild(3).gameObject.SetActive(false); // Return Button
        }

        public void PlayGame()
        {
            //play soundeffect
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);

            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            //play soundeffect
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);

            Application.Quit();
        }

        public void GetInfoPanel()
        {
            transform.GetChild(2).gameObject.SetActive(true);   // Info Panel
            transform.GetChild(3).gameObject.SetActive(true);   // Return Button 
            transform.GetChild(1).gameObject.SetActive(false);  // TitleScreen
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
        }

        public void ReturnToTitle()
        {
            transform.GetChild(2).gameObject.SetActive(false);   // Info Panel
            transform.GetChild(3).gameObject.SetActive(false);   // Return Button 
            transform.GetChild(1).gameObject.SetActive(true);  // TitleScreen
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
        }
    }
}
