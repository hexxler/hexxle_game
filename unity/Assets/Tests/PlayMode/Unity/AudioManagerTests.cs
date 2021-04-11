using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Hexxle.Tests.Unity
{
    public class AudioManagerTests
    {

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Titlescreen", LoadSceneMode.Single);
        }

        [UnityTest]
        public IEnumerator MainThemeSoundIsPlayingInMainScene()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);

            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

            yield return new WaitForSecondsRealtime(5);

            Assert.True(audioManager.backgroundMusics.Any(s => s.source.isPlaying));
        }

        [UnityTest]
        public IEnumerator MainThemeSoundIsPlayingInTitlescreenScene()
        {

            SceneManager.LoadScene("Titlescreen", LoadSceneMode.Single);

            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

            yield return new WaitForSecondsRealtime(5);

            Assert.True(audioManager.backgroundMusics.Any(s => s.source.isPlaying));
        }

        [UnityTest]
        public IEnumerator PlayPauseSound()
        {

            SceneManager.LoadScene("Titlescreen", LoadSceneMode.Single);

            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            AudioSource audioSource = audioManager.pauseSound.source;

            audioManager.Play(GameSoundTypes.PAUSE);

            int counter = 0;
            int counterMaxValue = 20;
            while(!audioSource.isPlaying && counter < counterMaxValue)
            {
                counter++;
                yield return null; // new WaitForSecondsRealtime(0);
            }

            Assert.True(counter < counterMaxValue);
        }

    }
}
