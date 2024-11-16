using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrapPool : MonoBehaviour
{
    TrapControler tControler;
    Dictionary<GameObject, List<GameObject>> fixTrapPool;
    Dictionary<GameObject, List<GameObject>> movableTrapPool;
    List<GameObject> enemyPool;

    private void Awake()
    {
        tControler = GetComponent<TrapControler>();
        fixTrapPool = new();
        movableTrapPool = new();
        enemyPool = new();
        foreach (var fix in tControler.fixTrap)
        {
            fixTrapPool[fix] = new();
        }
        foreach (var move in tControler.movableTrap)
        {
            movableTrapPool[move] = new();
        }
    }
    public GameObject GetTrap(bool easyPool, GameObject trap)
    {
        Dictionary < GameObject, List < GameObject >> selectedPool = easyPool? fixTrapPool: movableTrapPool;
        if (selectedPool.ContainsKey(trap))
        {
            foreach (GameObject selectedTrap in selectedPool[trap])
            {
                if (!selectedTrap.activeInHierarchy)
                {
                    selectedTrap.SetActive(true);
                    return selectedTrap;
                }
            }
            GameObject newTrap = Instantiate(trap);
            selectedPool[trap].Add(newTrap);
            return newTrap;
        }
        else
        {
            Debug.Log("Bay khong ton tai trong pool");
            return null;
        }
    }
    public GameObject GetEnemy(GameObject enemyPrefab)
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        GameObject newEnemy = Instantiate(enemyPrefab);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
}
