using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hexxle.Unity
{
    public class UnityUI : MonoBehaviour
    {
        public void exitRound()
        {
            //play soundeffect
            FindObjectOfType<AudioManager>().Play(GameSoundTypes.PAUSE);

            SceneManager.LoadScene("titlescreen", LoadSceneMode.Single);
        }
    }
}
