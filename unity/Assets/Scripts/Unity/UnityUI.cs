using Hexxle.Unity.Util;
using UnityEngine;
using UnityEngine.UI;
using Hexxle.Unity.Audio;

namespace Hexxle.Unity
{
    public class UnityUI : MonoBehaviour
    {
        public void PauseRound()
        {
            // activate PausePanel
            GameObjectFinder.PausePanel.SetActive(true);
            GameObjectFinder.MouseEventLogic.enabled = false;
            GameObjectFinder.TileTurnEventLogic.enabled = false;

            // play soundeffect
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.PAUSE);
        }
    }
}
