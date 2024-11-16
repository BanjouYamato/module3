using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttackState : GroundState
{
    public GroundAttackState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void EnterState(Player player)
    {
        anim.Play("Surprise Uppercut");
    }

    public override void ExitState(Player player)
    {
        base.ExitState(player);
    }
}
