using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds; 
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    // Update is called once per frame
    public void Play( string name) { 
        Sound s = Array.Find(sounds, s => s.name == name);
        s.source.Play();
    }
    
}
