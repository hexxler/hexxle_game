using System.Collections;
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
            AudioSource audioSource = null;

            //search for Elevator_Theme
            foreach (Sound sound in audioManager.sounds)
            {
                if (sound.name.Equals("ElevatorTheme"))
                {
                    audioSource = sound.source;
                    break;
                }
            }

            yield return new WaitForSecondsRealtime(1);

            Assert.True(audioSource.isPlaying);
        }

        [UnityTest]
        public IEnumerator MainThemeSoundIsPlayingInTitlescreenScene()
        {

            SceneManager.LoadScene("Titlescreen", LoadSceneMode.Single);

            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            AudioSource audioSource = null;

            //search for Elevator_Theme
            foreach (Sound sound in audioManager.sounds)
            {
                if (sound.name.Equals("ElevatorTheme"))
                {
                    audioSource = sound.source;
                    break;
                }
            }

            yield return new WaitForSecondsRealtime(1);

            Assert.True(audioSource.isPlaying);
        }

        [UnityTest]
        public IEnumerator PlayPauseSound()
        {

            SceneManager.LoadScene("Titlescreen", LoadSceneMode.Single);

            AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            AudioSource audioSource = null;

            audioManager.Play("Pause");

            //search for Elevator_Theme
            foreach (Sound sound in audioManager.sounds)
            {
                if (sound.name.Equals("Pause"))
                {
                    audioSource = sound.source;
                    break;
                }
            }

            yield return new WaitForSecondsRealtime(0);

            Assert.True(audioSource.isPlaying);
        }

    }
}
