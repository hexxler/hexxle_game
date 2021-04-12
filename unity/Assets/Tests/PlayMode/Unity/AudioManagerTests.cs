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

        private string sceneToLoad = "titlescreen";

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }

        [TearDown]
        public void TearDown()
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }

        [UnityTest]
        public IEnumerator MainThemeSoundIsPlayingInMainScene()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);

            yield return new WaitForSecondsRealtime(1);

            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);

            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

            Assert.True(audioManager.backgroundMusics.Any(s => s.source.isPlaying));
        }

        [UnityTest]
        public IEnumerator MainThemeSoundIsPlayingInTitlescreenScene()
        {
            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

            Assert.AreEqual("titlescreen", SceneManager.GetActiveScene().name);

            Assert.True(audioManager.backgroundMusics.Any(s => s.source.isPlaying));

            yield return null;
        }

        [UnityTest]
        public IEnumerator PlayPauseSound()
        {
            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            AudioSource audioSource = audioManager.pauseSound.source;

            audioManager.Play(GameSoundTypes.PAUSE);

            int counter = 0;
            int counterMaxValue = 20;
            while(!audioSource.isPlaying && counter < counterMaxValue)
            {
                counter++;
                yield return null;
            }

            Assert.True(counter < counterMaxValue);
        }

    }
}
