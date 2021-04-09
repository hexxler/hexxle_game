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
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
        [UnityTest]
        public IEnumerator MainThemeSoundIsPlaying()
        {

            AudioManager audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            AudioSource audioSource = null;

            //search for Elevator_Theme
            foreach (Sound sound in audioManager.sounds)
            {
                if (sound.name.Equals("Elevator_Theme"))
                {
                    audioSource = sound.source;
                    break;
                }
            }

            yield return new WaitForSecondsRealtime(1);

            Assert.True(audioSource.isPlaying);
        }


    }
}
