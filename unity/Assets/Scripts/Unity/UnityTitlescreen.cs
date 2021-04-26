using UnityEngine;
using UnityEngine.SceneManagement;
using Hexxle.Unity.Audio;
using UnityEngine.UIElements;

namespace Hexxle.Unity
{
    public class UnityTitlescreen : MonoBehaviour
    {
        public GameObject infoPanel;
        public GameObject optionsPanel;

        public void PlayGame()
        {
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            FindObjectOfType<SceneFadeManager>().LoadTransitionScene("Main", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            Application.Quit();
        }

        public void GetInfoPanel()
        {
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            infoPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }

        public void GetOptionsPanel()
        {
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            infoPanel.SetActive(false);
            optionsPanel.SetActive(true);
        }

        public void ReturnToTitle()
        {
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            infoPanel.SetActive(false);
            optionsPanel.SetActive(false);
        }
    }
}
