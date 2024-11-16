using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{   
    ItemPool cPool;
    MapControler mControler;
    PlayerControler pControler;
    public List<GameObject> Items;
    private void Awake()
    {
        cPool = GetComponent<ItemPool>();
        mControler = FindObjectOfType<MapControler>();
        pControler = FindObjectOfType<PlayerControler>();
    }
    public void CoinSpawn()
    {
        int rdCoins = Random.Range(5, 10);
        Vector3 lane = pControler.GetRandomLane();
        float firstPlaceAppear = Random.Range(1, 10);
        for (int i = 0; i < rdCoins; i++)
        {
            Vector3 startPoint = mControler.SegmentsList[1].transform.Find("StartPoint").position;
            Vector3 coinPos = new(lane.x, 0,startPoint.z + firstPlaceAppear + (i * 2));
            GameObject coin = cPool.GetItems(Items[0]);
            coin.transform.SetParent(transform);
            coin.transform.position = coinPos;
        }
    }
    public void BuffSpawn()
    {   
        int rdBuff = Random.Range(1, Items.Count);
        Vector3 lane = pControler.GetRandomLane();
        float buffPosZ = Random.Range(mControler.SegmentsList[1].transform.Find("StartPoint").position.z, mControler.SegmentsList[1].transform.Find("NextSpawnPoint").position.z);
        Vector3 itemPos = new(lane.x, 0, buffPosZ);
        GameObject itemBuff = cPool.GetItems(Items[rdBuff]);
        itemBuff.transform.SetParent(transform);
        itemBuff.transform.position = itemPos;
    }
}
