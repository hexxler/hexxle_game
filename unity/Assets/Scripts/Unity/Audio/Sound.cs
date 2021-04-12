using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound{

    public AudioClip clip;
    [Range(0,1)]
    public float volume;
    [Range(0,3)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop = false;

}
