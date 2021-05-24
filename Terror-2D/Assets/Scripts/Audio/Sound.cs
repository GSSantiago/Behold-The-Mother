using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public int number;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(-3f, 3f)]
    public float pitch;
    [Range(-1,1)]
    public int stereoPan; 

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
