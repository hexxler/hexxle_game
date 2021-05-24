using Hexxle.Unity.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hexxle.Unity
{
    public class UnitySettingsMenu : MonoBehaviour
    {
        public GameObject settingsMenu;
        public Slider[] VolumeSlider;

        void Start()
        {
            VolumeSlider[0].value = AudioManager.instance.musicVolumePercent;
            VolumeSlider[1].value = AudioManager.instance.sfxVolumePercent;
        }


        public void SetMusicVolume(float value)
        {
            AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
        }

        public void SetSfxVolume(float value)
        {
            AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);

        }
    }
}