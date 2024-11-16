using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueControl : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] public float musicVolume;
    public float soundVolume;
    public static VolumeValueControl Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        musicVolume = PlayerPrefs.GetFloat("Music", 0.5f);
        music.volume = musicVolume;
        soundVolume = PlayerPrefs.GetFloat("Sound", 0.5f);
    }
    public void SetMusicVolume(float volume)
    {   
        if (music != null)
            music.volume = volume;
        if (MusicSource.Instance != null)
            MusicSource.Instance.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("Music", volume);
        musicVolume = PlayerPrefs.GetFloat("Music", 0.5f);
    }
    public void SetSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat("Sound", volume);
        soundVolume = PlayerPrefs.GetFloat("Sound", 0.5f);
    }
}
