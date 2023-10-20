using UnityEngine.Audio;
using UnityEngine;

//make the variables for each clip appear in insppector
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector]
    public AudioSource source;
}   
