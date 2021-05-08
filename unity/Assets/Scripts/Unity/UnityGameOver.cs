using Hexxle.Unity.Audio;
using Hexxle.Unity.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityGameOver : MonoBehaviour
{
    public void InitGameOver()
    {
        if (!GameObjectFinder.GameOverPanel.activeSelf)
        {
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.POP);
            GameObjectFinder.GameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        FindObjectOfType<SceneFadeManager>().LoadTransitionScene("Main", LoadSceneMode.Single);
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<SceneFadeManager>().LoadTransitionScene("Titlescreen", LoadSceneMode.Single);
    }
}
