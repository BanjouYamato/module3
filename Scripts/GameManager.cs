using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public float speed;
    public float fallSPeed;
    public bool Death;
    public bool Attacking;
    public bool FallingToRoll;
    public float jumpForce;
    public bool GroundCheck;
    public bool TrapCheck;
    public bool IsHit;
    public float InvisibleTime;
    public float JumpBuffTime;
    public float ScoreBuffTime;
    public float CoinBuffTime;
    public bool IsBuffing;
    [SerializeField] int increaseCoin;
    int score;
    int coins;
    [SerializeField] int multipleScore;
    Vector3 lastPosPlayer;
    Transform Player;
    int hp;
    int nextStepScore = 10;
    int nextStepCoin = 10;
    [SerializeField] GameObject pausePanel;
    [SerializeField] RectTransform pauseMenu;
    [SerializeField] CanvasGroup darkScreen;
    [SerializeField] GameObject defeatPanel;
    [SerializeField] CanvasGroup darkScreenDefeat;
    [SerializeField] CanvasGroup defeatMenu;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }
    private void Start()
    {
        RenderSettings.ambientIntensity = 1.0f;
        RenderSettings.ambientLight = Color.white;
        MusicSource.Instance.PlayMusic(0);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPosPlayer = Player.position;
        multipleScore = 1;
        UIManager.Instance.ScoreScreen(score);
        UIManager.Instance.CoinsScreen(coins);
        hp = 100;
        UIManager.Instance.UpdateHpBar(hp);
        increaseCoin = 1;
        musicSlider.value = VolumeValueControl.Instance.musicVolume;
        musicSlider.value = VolumeValueControl.Instance.musicVolume;
        musicSlider.onValueChanged.AddListener(VolumeValueControl.Instance.SetMusicVolume);
        soundSlider.value = VolumeValueControl.Instance.soundVolume;
        soundSlider.onValueChanged.AddListener(VolumeValueControl.Instance.SetSoundVolume);
    }
    private void Update()
    {
        EffectItem();
        UpdateScore();
        UIManager.Instance.ScoreScreen(score);
        UIManager.Instance.CoinsScreen(coins);
        UIManager.Instance.UpdateHpBar(hp);
        DeathNote();
        UpdateScorePanel();
        UpdateCoinsPanel();
    }
    void UpdateScore()
    {   
        float distanceMove = (Player.position.z - lastPosPlayer.z) * 10;
        int addScore = Mathf.RoundToInt(distanceMove) * multipleScore;
        score += addScore;
        lastPosPlayer = Player.position;
    }
    public void IncreasementSpeed()
    {
        speed += 0.5f;
    }
    public void UpdateCoin()
    {
        coins += increaseCoin;
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }
    public void DeathNote()
    {   
        if (!Death && hp == 0)
        {
            Death = true;
            MusicSource.Instance.PlaySound(14, 1f);
        }
    }
    void UpdateScoreBuffTime()
    {
        if (ScoreBuffTime == 0)
            multipleScore = 1;
        else
            multipleScore = 2;
    }
    void UpdateCoinBuffItem()
    {
        if (CoinBuffTime == 0)
            increaseCoin = 1;
        else
            increaseCoin = 2;
    }
    void EffectItem()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        InvisibleTime = Mathf.Clamp(InvisibleTime, 0, 5);
        JumpBuffTime = Mathf.Clamp(JumpBuffTime, 0, 5);
        ScoreBuffTime = Mathf.Clamp(ScoreBuffTime, 0, 5);
        CoinBuffTime = Mathf.Clamp(CoinBuffTime, 0, 5);
        if (InvisibleTime > 0)
            InvisibleTime -= Time.deltaTime;
        else
            IsBuffing = false;
        if (JumpBuffTime > 0)
            JumpBuffTime -= Time.deltaTime;
        if (ScoreBuffTime > 0)
        {
            multipleScore = 2;
            ScoreBuffTime -= Time.deltaTime;
        }
        else
            multipleScore = 1;
        if (CoinBuffTime > 0)
        {
            increaseCoin = 2;
            CoinBuffTime -= Time.deltaTime;
        }
        else
            increaseCoin = 1;
    }
    public void Pause()
    {   
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        PauseIntro();
    }
    void PauseIntro()
    {   
        darkScreen.DOFade(1, 0.5f).SetUpdate(true);
        pauseMenu.DOAnchorPosY(0, 0.5f).SetUpdate(true);
    }
    public async void Resume()
    {
        await PauseOutro();
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    async Task PauseOutro()
    {
        darkScreen.DOFade(0, 0.5f).SetUpdate(true);
        await pauseMenu.DOAnchorPosY(450, 0.5f).SetUpdate(true).AsyncWaitForCompletion();
    }
    public void Defeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
        DefeatIntro();
    }
    void DefeatIntro()
    {
        darkScreenDefeat.DOFade(1, 1f).SetUpdate(true);
        defeatMenu.DOFade(1, 1f).SetUpdate(true);
        UIManager.Instance.UpdateDefeatScoreText(score);
        UIManager.Instance.UpdateDefeatCoinsText(coins);
    }
    public void Replay()
    {
        SceneManager.LoadScene("GameScence");
        DOTween.KillAll();
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScence");
        DOTween.KillAll();
        Time.timeScale = 1;
    }
    void UpdateScorePanel()
    {
        if (score >= nextStepScore)
        {
            UIManager.Instance.UpdateRectransformScore();
            nextStepScore *= 10;
        }
    }
    void UpdateCoinsPanel()
    {
        if (coins >= nextStepCoin)
        {
            UIManager.Instance.UpdateRectransformCoins();
            nextStepCoin *= 10;
        }
    }
    public void KillEnemy(int score, int coin)
    {
        this.score += score;
        this.coins += coin;
    }
}
