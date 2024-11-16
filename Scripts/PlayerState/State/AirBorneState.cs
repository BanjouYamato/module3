using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBorneState : BaseState
{
    public AirBorneState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void UpdateState(Player player)
    {   
        if (!GameManager.Instance.Death)
        {   
            if (!GameManager.Instance.GroundCheck)
            {
                state.TransitionState(state.jumpUpState);
            }
            else
                state.TransitionState(state.groundState);
        }
        else
            state.TransitionState(state.deathState);
    }
}
