using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPool : MonoBehaviour
{   
    MapControler mControler;
    Dictionary<GameObject, List<GameObject>> easySegmentPools;

    private void Awake()
    {
        mControler = GetComponent<MapControler>();
        easySegmentPools = new();
        foreach (var easy in mControler.EasySegments)
        {
            easySegmentPools[easy] = new();
        }
    }
    public GameObject GetSegment(GameObject segment)
    {
        if (easySegmentPools.ContainsKey(segment))
        {
            foreach (GameObject selectedSegment in easySegmentPools[segment])
            {
                if (!selectedSegment.activeInHierarchy)
                {
                    selectedSegment.SetActive(true);
                    return selectedSegment;
                }
            }
            GameObject newSegment = Instantiate(segment);
            easySegmentPools[segment].Add(newSegment);
            return newSegment;
        }
        else
        {
            return null;
        }
    }
}
