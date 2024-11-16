using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] RectTransform scoreRectTransform;
    [SerializeField] RectTransform scoreTextRectTransform;
    [SerializeField] RectTransform coinsRectTransform;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] RectTransform hpbar;
    [SerializeField] TextMeshProUGUI defeatScoreText;
    [SerializeField] TextMeshProUGUI defeatCoinsText;
    [SerializeField] Texture[] characterAvatar;
    [SerializeField] RawImage avatar;
    public static UIManager Instance {  get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        int index = PlayerPrefs.GetInt("Character", 0);
        avatar.texture = characterAvatar[index];
    }
    public void ScoreScreen(int  score)
    {
        scoreText.text = score.ToString();
        if (GameManager.Instance.ScoreBuffTime > 0)
        {
            scoreText.color = Color.yellow;
        }
        else
            scoreText.color = Color.white;
    }
    public void CoinsScreen(int coins)
    {
        coinsText.text = coins.ToString();
        if (GameManager.Instance.CoinBuffTime > 0)
        {
            coinsText.color = Color.yellow;
        }
        else
            coinsText.color = Color.white;
    }
    public void UpdateSizeScoreText()
    {
        Vector2 sizeDelta = scoreRectTransform.sizeDelta;
        sizeDelta.x += 20;
        scoreRectTransform.sizeDelta = sizeDelta;
        Vector2 scoreTextSizeDelta = scoreTextRectTransform.sizeDelta;
        scoreTextSizeDelta.x += 20;
        scoreTextRectTransform.sizeDelta = scoreTextSizeDelta;
    }
    public void UpdateHpBar(int hp)
    {
        hpbar.sizeDelta = new(hp * 2, hpbar.sizeDelta.y); 
    }
    public void UpdateDefeatScoreText(int score)
    {
        defeatScoreText.text = "SCORE: " + score;
    }
    public void UpdateDefeatCoinsText(int coins)
    {
        defeatCoinsText.text = coins.ToString();
    }
    public void UpdateRectransformScore()
    {
        scoreRectTransform.sizeDelta += new Vector2(20, 0); 
    }
    public void UpdateRectransformCoins()
    {
        coinsRectTransform.sizeDelta += new Vector2(20, 0);
    }
}
