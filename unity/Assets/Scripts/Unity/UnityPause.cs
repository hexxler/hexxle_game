using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene("titlescreen", LoadSceneMode.Single);
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
