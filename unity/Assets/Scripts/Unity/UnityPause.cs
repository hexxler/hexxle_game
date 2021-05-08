using Hexxle.Unity.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityPause : MonoBehaviour
{
    public void ResumeRound()
    {
        // deactivate PausePanel
        GameObjectFinder.PausePanel.SetActive(false);
        GameObjectFinder.MouseEventLogic.enabled = true;
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
