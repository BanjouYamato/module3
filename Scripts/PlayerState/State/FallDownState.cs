using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownState : AirBorneState
{
    public FallDownState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void EnterState(Player player)
    {
        anim.Play("Falling To Landing");
    }

    public override void ExitState(Player player)
    {
        base.ExitState(player);
    }
}
