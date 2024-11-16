using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float switchLaneSpeed;
    Lane currrentLane;
    public Dictionary<Lane, Vector3> lanePositions = new Dictionary<Lane, Vector3>()
    {
        {Lane.Left, new(-3f, 0f, 0f)},
        {Lane.Middle, new(0f, 0f, 0f)},
        {Lane.Right, new(3f, 0f, 0f)},
    };
    private void Start()
    {
        currrentLane = Lane.Middle;
    }
    public void InputSwitchLane()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currrentLane != Lane.Left)
            currrentLane -= 1;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currrentLane != Lane.Right)
            currrentLane += 1;
    }
    public void SwitchLane()
    {
        Vector3 targetPos = new(lanePositions[currrentLane].x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, switchLaneSpeed * Time.fixedDeltaTime);
    }
    public Vector3 GetRandomLane()
    {
        List<Lane> lanes = new List<Lane>(lanePositions.Keys);
        int rdIndex = Random.Range(0, lanes.Count);
        return lanePositions[lanes[rdIndex]];
    }
    public float GetLaneX()
    {
        return lanePositions[currrentLane].x;
    }
}
