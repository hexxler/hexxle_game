using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Hexxle.Unity
{
    public class UnityUI : MonoBehaviour
    {
        public void PauseRound()
        {
            var uiPanel = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).gameObject;

            // activate PausePanel
            var pauseCanvas = GameObject.FindGameObjectWithTag("Pause");
            pauseCanvas.transform.GetChild(0).gameObject.SetActive(true);

            // disable Buttons in UI
            foreach (Button button in uiPanel.GetComponentsInChildren<Button>())
            {
                button.enabled = false;
            }
        }
    }
}
