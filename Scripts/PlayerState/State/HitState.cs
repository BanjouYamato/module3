using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : BaseState
{
    public HitState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void EnterState(Player player)
    {
        base.EnterState(player);
        anim.Play("Head Hit");
    }

    public override void ExitState(Player player)
    {
        base.ExitState(player);
    }

    public override void UpdateState(Player player)
    {
        if (!GameManager.Instance.IsHit)
        {
            if (!GameManager.Instance.GroundCheck)
            {
                state.TransitionState(state.airBorneState);
            }
            else
                state.TransitionState(state.groundState);
        }
        else
            state.TransitionState(state.hitState);
    }
}
