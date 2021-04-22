using Hexxle.Unity.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityPause : MonoBehaviour
{
    public void Awake()
    {
        // pause screen starts off as disabled
        this.gameObject.SetActive(false);
        GameObjectFinder.PauseModal.SetActive(false);
        DisableModalChildPanels();
    }
    public void ResumeRound()
    {
        // deactivate PausePanel
        GameObjectFinder.PausePanel.SetActive(false);
        GameObjectFinder.MouseEventLogic.enabled = true;

        // enable Buttons in UI
        foreach (Button button in GameObjectFinder.UIPanel.GetComponentsInChildren<Button>())
        {
            button.enabled = true;
        }
    }

    public void ShowInfo()
    {
        GameObjectFinder.PauseModal.SetActive(true);
        GameObjectFinder.InfoPanel.SetActive(true);
    }

    public void Back()
    {
        DisableModalChildPanels();
        // Disable PauseModal itself
        GameObjectFinder.PauseModal.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<SceneFadeManager>().LoadTransitionScene("Titlescreen", LoadSceneMode.Single);
    }

    private void DisableModalChildPanels()
    {
        var pauseModal = GameObjectFinder.PauseModal;
        var childCount = pauseModal.transform.childCount;
        // Disable any children of PauseModal apart from the BackButton (index 0)
        for (int index = 1; index < childCount; index++)
        {
            pauseModal.transform.GetChild(index).gameObject.SetActive(false);
        }
    }
}
