using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamPointPlayer : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    GameObject player;
    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Transform camPoint = player.transform.GetChild(1).transform;
        cam.Follow = camPoint;
    }
}
