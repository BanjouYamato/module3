using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSource : MonoBehaviour
{
    AudioSource musicSource;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip[] musicsList;
    [SerializeField] AudioClip[] SoundsList;
    public static MusicSource Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        musicSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        musicSource.volume = VolumeValueControl.Instance.musicVolume;
    }
    public void PlayMusic(int index)
    {
        musicSource.clip = musicsList[index];
        musicSource.Play();
        musicSource.loop = true;
    }
    public AudioClip GetSound(int index)
    {
        return SoundsList[index];
    }
    public void PlaySound(int index, float volume)
    {
        float totalVolume = PlayerPrefs.GetFloat("Sound", 0.5f);
        soundSource.PlayOneShot(SoundsList[index], volume * totalVolume);
    }
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
