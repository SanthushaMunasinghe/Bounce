using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> gameSFX = new List<AudioSource>();

    void Start()
    {
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            foreach (AudioSource source in gameSFX)
            {
                source.mute = true;
            }
        }
        else
        {
            foreach (AudioSource source in gameSFX)
            {
                source.mute = false;
            }
        }
    }
}
