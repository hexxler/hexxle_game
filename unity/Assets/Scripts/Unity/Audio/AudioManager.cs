using Random = System.Random;
using System.Collections.Generic;
using UnityEngine;

namespace Hexxle.Unity.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        private Random rnd = new Random();
        public List<Sound> popSounds = new List<Sound>();
        public List<Sound> backgroundMusics = new List<Sound>();
        public Sound pauseSound;
        public Sound RotationSound;
        public enum AudioChannel {Music, Sfx};
        public float musicVolumePercent { get; private set; } = 0.5f;
        public float sfxVolumePercent { get; private set; } = 0.5f;


        void Awake()
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

            DontDestroyOnLoad(gameObject);

            AddAudioSource(popSounds);
            AddAudioSource(backgroundMusics);
            AddAudioSource(new List<Sound> { pauseSound, RotationSound });

        }

        void Start()
        {
            //start main theme here
            Play(GameSoundTypes.BACKGROUND);
        }

        public void Play(GameSoundTypes soundType)
        {
            switch (soundType)
            {
                case GameSoundTypes.BACKGROUND:
                    {
                        backgroundMusics[rnd.Next(backgroundMusics.Count)].source.Play();
                        break;
                    }
                case GameSoundTypes.POP:
                    {
                        popSounds[rnd.Next(popSounds.Count)].source.Play();
                        break;
                    }
                case GameSoundTypes.PAUSE:
                    {
                        pauseSound.source.Play();
                        break;
                    }
                case GameSoundTypes.ROTATE:
                    {
                        RotationSound.source.Play();
                        break;
                    }
            }
        }

        public void SetVolume(float value, AudioChannel channel)
        {
            switch(channel)
            {
                case AudioChannel.Music:
                    musicVolumePercent = value;
                    break;
                case AudioChannel.Sfx:
                    sfxVolumePercent = value;
                    break;
                default:
                    break;
            }
        }

        private void AddAudioSource(List<Sound> sounds)
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
    }

    public enum GameSoundTypes
    {
        BACKGROUND,
        POP,
        PAUSE,
        ROTATE
    }
}
