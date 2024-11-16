using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpState : AirBorneState
{
    public JumpUpState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void EnterState(Player player)
    {
        anim.Play("Jumping");
    }

    public override void ExitState(Player player)
    {
        base.ExitState(player);
    }
}
