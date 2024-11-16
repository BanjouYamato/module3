using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{
    public GameObject[] EasySegments;
    public List<GameObject> SegmentsList = new List<GameObject>();
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject startPlace;
    Vector3 nextSpawnPoint;
    Vector3 startPoint;
    int previousIndex = -1;
    SegmentPool SegmentPool;
    TrapControler TrapControler;
    PlayerControler pControler;
    TrapPool TrapPool;
    public Transform TrapWarehouse;
    public bool selectTrap = true;
    ItemManager iManager;
    int countSegments;
    public GameObject EnemyPrefab;
    private void Awake()
    {   
        pControler = FindObjectOfType<PlayerControler>();
        SegmentPool = GetComponent<SegmentPool>();
        TrapControler = FindObjectOfType<TrapControler>();
        TrapPool = FindObjectOfType<TrapPool>();
        iManager = FindObjectOfType<ItemManager>();
    }
    private void Start()
    {
        nextSpawnPoint = SpawnPoint.position;
        AddToMapList();
        SpawnTrap();
        iManager.CoinSpawn();
    }
    void AddToMapList()
    {
        SegmentsList.Add(startPlace);
        for (int i = 0; i < 4; i++)
        {
            CreateSegments();
        }
    }
    int PickerRandomIndex(int minValue, int maxValue)
    {
        int newNumbers;
        do
        {
            newNumbers = Random.Range(minValue, maxValue);
        }    
        while (newNumbers == previousIndex);
        previousIndex = newNumbers;
        return newNumbers;
    }
    public void PassOneSegment()
    {
        int rdTypeTrap = Random.Range(0, 2);
        selectTrap = rdTypeTrap == 0? true: false;
        countSegments++;
        TrapControler.TypeTrap();
        CreateSegments();
        StartCoroutine(RemoveGameobject());
        SpawnTrap();
        iManager.CoinSpawn();
        ItemSpawn();
        GameManager.Instance.IncreasementSpeed();
        EnemySpawn();
    }
    void CreateSegments() 
    {
        GameObject segment = SegmentPool.GetSegment(EasySegments[PickerRandomIndex(0, EasySegments.Length)]);
        segment.transform.SetParent(transform);
        SegmentsList.Add(segment);
        startPoint = segment.transform.Find("StartPoint").position;
        Vector3 offset = nextSpawnPoint - startPoint;
        segment.transform.position += offset;
        nextSpawnPoint = segment.transform.Find("NextSpawnPoint").position;
    }
    IEnumerator RemoveGameobject()
    {
        GameObject removeSegment = SegmentsList[0];
        SegmentsList.RemoveAt(0);
        yield return new WaitForSeconds(3f);
        removeSegment.gameObject.SetActive(false);
    }
    public void SpawnTrap()
    {   
        for (int i = 0; i < 3; i++)
        {
            float trapPosZ = Random.Range(SegmentsList[1].transform.Find("StartPoint").position.z, SegmentsList[1].transform.Find("NextSpawnPoint").position.z);
            GameObject Trap = TrapPool.GetTrap(selectTrap,TrapControler.GetTrap());
            Trap.transform.SetParent(TrapWarehouse);
            Trap.transform.position = new Vector3(pControler.GetRandomLane().x, 0, trapPosZ);
        }
    }
    void ItemSpawn()
    {
        if (countSegments % 3 == 0)
            iManager.BuffSpawn();
    }
    void EnemySpawn()
    {   
        if (countSegments % 2 == 0)
        {
            float enemyPosZ = Random.Range(SegmentsList[1].transform.Find("StartPoint").position.z, SegmentsList[1].transform.Find("NextSpawnPoint").position.z);
            GameObject enemy = TrapPool.GetEnemy(EnemyPrefab);
            enemy.transform.SetParent(TrapWarehouse);
            enemy.transform.position = new Vector3(pControler.GetLaneX(), 0, enemyPosZ);
        }
    }    
}
