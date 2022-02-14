using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;

    public static AudioManager instance;

    void Awake()
    {
        SingletonThisObject();

        foreach (Sound s in _sounds)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s._clip;

            s._source.volume = s._volume;
            s._source.pitch = s._pitch;
            s._source.loop = s._loop;
        }
    }

    void Start()
    {
        PlaySound("MainTheme");
    }

    public void PlaySound (string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s._source.Play();
    }

    void SingletonThisObject()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
