using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : GroundState
{
    public RollState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void EnterState(Player player)
    {
        anim.Play("Falling To Roll");
    }

    public override void ExitState(Player player)
    {
        base.ExitState(player);
    }
}
