using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] RectTransform titleGame;
    [SerializeField] RectTransform settingButton;
    [SerializeField] RectTransform shopButton;
    [SerializeField] CanvasGroup start;
    [SerializeField] GameObject startGamePanel;
    [SerializeField] GameObject Setting;
    [SerializeField] CanvasGroup SettingDark;
    [SerializeField] CanvasGroup settingMenu;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    private void Start()
    {
        MusicSource.Instance.PlayMusic(1);
        musicSlider.value = VolumeValueControl.Instance.musicVolume;
        soundSlider.value = VolumeValueControl.Instance.soundVolume;
        MoveTitleGame();
        RenderSettings.ambientIntensity = 1.0f;
        RenderSettings.ambientLight = Color.white;
    }
    void MoveTitleGame()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(titleGame.DOAnchorPosX(0, 1f));
        mySequence.Append(settingButton.DOAnchorPosX(340, 0.5f));
        mySequence.Join(shopButton.DOAnchorPosY(160, 0.5f));
        mySequence.Append(start.DOFade(1, 0.5f)
            .SetLoops(1000000, LoopType.Yoyo)
            .SetEase(Ease.InOutSine));
        mySequence.Join(DOTween.To(() => 0, x => { }, 1, 0f)
            .OnStart(() => startGamePanel.SetActive(true)));
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScence");
        DOTween.KillAll();
    }
    public void SettingMenu()
    {
        Setting.SetActive(true);
        SettingMenuIntro();
        Time.timeScale = 0;
    }
    void SettingMenuIntro()
    {
        SettingDark.DOFade(1, 0.5f)
            .SetEase(Ease.Linear)
            .SetUpdate(true);
        settingMenu.DOFade(1, 0.5f)
            .SetEase(Ease.Linear)
            .SetUpdate(true);

    }
    public void OutSettingMenu()
    {
        Time.timeScale = 1;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(SettingDark.DOFade(0, 0.5f));
        sequence.Join(settingMenu.DOFade(0, 0.5f));
        sequence.OnComplete(() => Setting.SetActive(false));
    }
    public void EnterShop()
    {
        SceneManager.LoadScene("Shop");
        DOTween.KillAll();
    }
}
