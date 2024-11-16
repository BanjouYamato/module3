using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : GroundState
{
    public RunningState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void EnterState(Player player)
    {
        anim.Play("Run");
    }

    public override void ExitState(Player player)
    {
        base.ExitState(player);
    }
}
