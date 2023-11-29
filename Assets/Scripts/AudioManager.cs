using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource AmbienceSource;

    [Header("Audio Clips")]
    public AudioClip backGround;
    public AudioClip Ambience;

    public static AudioManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = backGround; 
        AmbienceSource.clip = Ambience;
        musicSource.Play();
        AmbienceSource.Play();
    }
}
