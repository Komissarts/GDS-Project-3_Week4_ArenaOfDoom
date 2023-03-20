using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;

    public Sound[] sfx;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }


    public void PlaySFX(string name)
    {   
        Sound s = Array.Find(sfx, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else 
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
