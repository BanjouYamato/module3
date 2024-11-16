using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlayer : MonoBehaviour
{
    int playerIndex;
    Vector3 spawnPoint = new(0, 0, -9.4f);
    private void Awake()
    {
        playerIndex = PlayerPrefs.GetInt("Character", 0);
        switch(playerIndex)
        {
            case 0:
                GameObject AJ = Resources.Load<GameObject>("Player/AJ");
                Instantiate(AJ, spawnPoint, Quaternion.identity);
                break;
            case 1:
                GameObject MC = Resources.Load<GameObject>("Player/Michelle");
                Instantiate(MC, spawnPoint, Quaternion.identity);
                break;
            default:
                break;
        }
    }

}
