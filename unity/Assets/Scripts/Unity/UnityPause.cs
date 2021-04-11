using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityPause : MonoBehaviour
{
    public void ResumeRound()
    {
        var uiPanel = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).gameObject;

        // deactivate PausePanel
        var pauseCanvas = GameObject.FindGameObjectWithTag("Pause");
        pauseCanvas.transform.GetChild(0).gameObject.SetActive(false);

        // enable Buttons in UI
        foreach (Button button in uiPanel.GetComponentsInChildren<Button>())
        {
            button.enabled = true;
        }
    }

    public void ShowInfo()
    {

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("titlescreen", LoadSceneMode.Single);
    }
}
