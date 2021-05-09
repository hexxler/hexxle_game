using Hexxle.Unity.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityPause : MonoBehaviour
{
    public void ResumeRound()
    {
        GameObjectFinder.PausePanel.SetActive(false);
        GameObjectFinder.MouseEventLogic.enabled = true;
        GameObjectFinder.TileTurnEventLogic.enabled = true;
    }

    public void ShowInfo()
    {
        GameObjectFinder.InfoPanel.SetActive(true);
    }

    public void Back()
    {
        GameObjectFinder.InfoPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<SceneFadeManager>().LoadTransitionScene("Titlescreen", LoadSceneMode.Single);
    }
}
