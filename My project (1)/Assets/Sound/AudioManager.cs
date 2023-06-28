using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //Tutorial followed by Brackeys: https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys

    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        //if (instance == null)
        //{
        //    instance = this;
        //}
        
        //Atributes for each sound clip
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.spatialBlend = s.spatialBlend;

            s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;

        }
    }

    //Play the sound
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    //Play the sound after a delay in seconds
    public void PlayDelayed (string name, float delay)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.PlayDelayed(delay);
    }
    
    //Pause the sound
    public void Pause (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Pause();
    }
    
    //Un Pause the sound
    public void UnPause (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.UnPause();
    } 

    //Stop the sound
    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    } 

    //Check if the sound is playing
    public bool isPlaying (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
        }
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
