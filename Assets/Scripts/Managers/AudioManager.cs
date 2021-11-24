using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance; 

    // Start is called before the first frame update
    void Awake ()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme"); // <- Plays Background Music from Audiomanager
    }

    public void Play(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i] != null && sounds[i].name == name)
            {
                sounds[i].source.Play();
                return;
            }

        }
        Debug.LogWarning("Sound: " + name + " not found!");


    }

    }
