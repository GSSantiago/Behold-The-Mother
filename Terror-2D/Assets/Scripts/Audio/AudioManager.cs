using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;


    // Start is called before the first frame update
    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.panStereo = s.stereoPan;
            s.source.playOnAwake = s.playOnAwake;
        }
    }
    
    public void Play(int number)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);
        s.source.Play();
    }

    public void Stop (int number)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);

        s.source.Stop();
    }

    public void stereoPan(int number, int i)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);

        s.source.panStereo = i;
    }

    public bool isPlaying(int number)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);

        return s.source.isPlaying;

    }

    public void Volume(int number, float i)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);

        s.source.volume = i;
    }


}
