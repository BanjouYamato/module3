using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    int currentIndex;
    public int[] UnlockedCharacter = new int[2] { 1, 0 };
    [SerializeField] GameObject buyButton;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] int[] price = new int[2];
    int totalCoin;
    [SerializeField] TextMeshProUGUI totalCoinText;
    private void Awake()
    {
        for (int i = 1; i < UnlockedCharacter.Length; i++)
        {
            UnlockedCharacter[i] = PlayerPrefs.GetInt("UnlockedChar", 0);
        }
    }
    private void Start()
    {
        MusicSource.Instance.PlayMusic(0);
        totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);
        totalCoinText.text = totalCoin.ToString();
        currentIndex = PlayerPrefs.GetInt("Character", 0);
        SelectedCharacter(currentIndex);
    }
    private void Update()
    {
        CheatEditor();
        totalCoinText.text = totalCoin.ToString(); 
    }
    void SelectedCharacter(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        if (UnlockedCharacter[index] == 1)
        {
            buyButton.SetActive(false);
        }
        else
        {
            buyButton.SetActive(true);
            priceText.text = price[index].ToString();
        }
    }
    public void NextCharacter()
    {
        currentIndex++;
        if (currentIndex > transform.childCount - 1)
            currentIndex = 0;
        SelectedCharacter(currentIndex);
        if (UnlockedCharacter[currentIndex] == 1)
        {
            PlayerPrefs.SetInt("Character", currentIndex);
        }
    }
    public void PreviousCharacter()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = transform.childCount - 1;
        SelectedCharacter(currentIndex);
        if (UnlockedCharacter[currentIndex] == 1)
        {
            PlayerPrefs.SetInt("Character", currentIndex);
        }
    }
    public void BuyCharacter()
    {
        if (totalCoin >= price[currentIndex])
        {
            UnlockedCharacter[currentIndex] = 1;
            totalCoin -= price[currentIndex];
            buyButton.SetActive(false);
            SelectedCharacter(currentIndex);
            PlayerPrefs.SetInt("Character", currentIndex);
            PlayerPrefs.SetInt("TotalCoin", totalCoin);
            PlayerPrefs.SetInt("UnlockedChar", UnlockedCharacter[currentIndex]);
        }
    }
    void CheatEditor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PlayerPrefs.DeleteAll();
        if (Input.GetKeyDown(KeyCode.E))
        {
            totalCoin += 10;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            totalCoin -= 10;
        }
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenuScence");
    }
}
