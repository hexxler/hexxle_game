using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Hexxle.Unity
{
    public class UnityUI : MonoBehaviour
    {
        public void PauseRound()
        {
            // activate PausePanel
            GameObjectFinder.PausePanel.SetActive(true);

            // disable Buttons in UI
            foreach (Button button in GameObjectFinder.UIPanel.GetComponentsInChildren<Button>())
            {
                button.enabled = false;
            }
        }
    }
}
