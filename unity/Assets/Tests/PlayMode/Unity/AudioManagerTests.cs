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

            foreach(Sound sound in audioManager.backgroundSounds){
                if (sound.source.isPlaying)
                {
                    audioSource = sound.source;
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

            foreach (Sound sound in audioManager.backgroundSounds)
            {
                if (sound.source.isPlaying)
                {
                    audioSource = sound.source;
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
