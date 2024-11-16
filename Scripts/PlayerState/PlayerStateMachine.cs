using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    BaseState currentState;
    Player player;
    public GroundState groundState;
    public RunningState runningState;
    public RollState rollState;
    public GroundAttackState AttackState;
    public AirBorneState airBorneState;
    public JumpUpState jumpUpState;
    public FallDownState fallDownState;
    Animator Anim;
    public DeathState deathState;
    public HitState hitState;
    private void Awake()
    {   
        player = GetComponent<Player>();
        Anim = transform.GetChild(2).GetComponent<Animator>();
        groundState = new(this, Anim);
        runningState = new(this, Anim);
        rollState = new(this, Anim);
        airBorneState = new(this, Anim);
        jumpUpState = new(this, Anim);
        fallDownState = new(this, Anim);
        AttackState = new(this, Anim);
        deathState = new(this, Anim);
        hitState = new(this, Anim);
    }
    private void Start()
    {
        currentState = runningState;
    }
    private void Update()
    {
        currentState.UpdateState(player);
    }
    public void TransitionState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(player);
    }
}
