using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrapControler : MonoBehaviour
{
    public GameObject[] fixTrap;
    public GameObject[] movableTrap;
    MapControler mControler;
    PlayerControler pControler;
    [SerializeField] List<GameObject> selectedTypeTrap;
    private void Awake()
    {
        mControler = FindObjectOfType<MapControler>();
        pControler = FindObjectOfType<PlayerControler>();
        selectedTypeTrap = new List<GameObject>();
        TypeTrap();
    }
    public GameObject GetTrap()
    {   
        if (selectedTypeTrap.Count > 0)
        {
            int rdTrap = Random.Range(0, selectedTypeTrap.Count);
            return selectedTypeTrap[rdTrap];
        }
        Debug.Log("SelectedTypeTrap count = 0 trapcontroler");
        return null;
        
    }
    public void TypeTrap()
    {
        if (mControler.selectTrap)
            selectedTypeTrap = fixTrap.ToList();
        else
            selectedTypeTrap = movableTrap.ToList();
    }
}
