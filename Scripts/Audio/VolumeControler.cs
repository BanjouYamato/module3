using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControler : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    public static VolumeControler Instance { get; private set; }
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
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        musicSlider.onValueChanged.AddListener(VolumeValueControl.Instance.SetMusicVolume);
        soundSlider.value = PlayerPrefs.GetFloat("Sound", 0.5f);
        soundSlider.onValueChanged.AddListener(VolumeValueControl.Instance.SetSoundVolume);
    }
}
