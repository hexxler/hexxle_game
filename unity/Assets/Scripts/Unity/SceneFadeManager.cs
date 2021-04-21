using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeManager : MonoBehaviour
{
    public static SceneFadeManager instance;
    public Animator transition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void LoadTransitionScene(string sceneName, LoadSceneMode mode)
    {
        StartCoroutine(TransitionScene(sceneName, mode));
    }

    IEnumerator TransitionScene(string sceneName, LoadSceneMode mode)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName, mode);
    }
}
