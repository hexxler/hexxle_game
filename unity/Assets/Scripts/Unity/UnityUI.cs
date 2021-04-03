using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hexxle.Unity
{
    public class UnityUI : MonoBehaviour
    {
        public void exitRound()
        {
            SceneManager.LoadScene("titlescreen", LoadSceneMode.Single);
        }
    }
}
