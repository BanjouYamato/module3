using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    PlayerAction action;
    CheckGround collision;
    PlayerControler controler;
    MapControler mapControler;
    [SerializeField] bool newSegment = true;
    private void Awake()
    {   
        mapControler = FindObjectOfType<MapControler>();
        action = GetComponent<PlayerAction>();
        collision = transform.GetChild(3).GetComponent<CheckGround>();
        controler = GetComponent<PlayerControler>();
    }
    void Update()
    {
        InputAction();
        action.FallGravity();
        controler.InputSwitchLane();
        Deathly();
    }
    void FixedUpdate()
    {   
        controler.SwitchLane();
        action.ApplyInvisible();
    }
    void InputAction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && GameManager.Instance.GroundCheck)
        {
            MusicSource.Instance.PlaySound(7, 1);
            action.ApplyJumpBuff();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && GameManager.Instance.GroundCheck)
            action.PlayerRoll();
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !GameManager.Instance.GroundCheck)
        {
            action.Fall(GameManager.Instance.fallSPeed);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.GroundCheck)
            action.Attack();
    }
    public Rigidbody GetRigidbody() { return action.rb; }
    private void OnTriggerEnter(Collider other)
    {   
        if (newSegment)
        {
            if (other.CompareTag("TriggerMap"))
            {   
                newSegment = false;
                mapControler.PassOneSegment();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TriggerMap"))
        {
            newSegment = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerMap"))
        {
            newSegment = true;
        }
    }
    private void OnCollisionEnter(Collision col)
    {   
        if (col.gameObject.CompareTag("Trap") && !GameManager.Instance.TrapCheck && !GameManager.Instance.Death)
        {
            GameManager.Instance.TakeDamage(100);
            MusicSource.Instance.PlaySound(6, 1f);
        }
        if (col.gameObject.CompareTag("Enemy") && !GameManager.Instance.IsHit)
        {
            GameManager.Instance.TakeDamage(20);
            MusicSource.Instance.PlaySound(17, 1f);
            action.GetHit();

        }
    }
    void Deathly()
    {
        if (GameManager.Instance.Death)
        {
            action.Death();
        }
    }
}
