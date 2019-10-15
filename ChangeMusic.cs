using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip level1Music;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            source.clip = level1Music;
        }
            
    }
}
