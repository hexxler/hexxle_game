using System;
using Random = System.Random;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private Random rnd = new Random();
    public List<Sound> popSounds = new List<Sound>();
    public List<Sound> backgroundSounds = new List<Sound>();
    public List<Sound> pauseSounds = new List<Sound>();

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
        AddAudioSource(backgroundSounds);
        AddAudioSource(pauseSounds);

    }

    void Start()
    {
        //start main theme here
        Play(GameSoundTypes.BACKGROUND);
    }

    public void Play(GameSoundTypes soundType)
    {
        switch(soundType){
            case GameSoundTypes.BACKGROUND:
                {
                    backgroundSounds[rnd.Next(backgroundSounds.Count)].source.Play();
                    break;
                }
            case GameSoundTypes.POP:
                {
                    popSounds[rnd.Next(popSounds.Count)].source.Play();
                    break;
                }
            case GameSoundTypes.PAUSE:
                {
                    pauseSounds[rnd.Next(pauseSounds.Count)].source.Play();
                    break;
                }
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
    PAUSE
}
