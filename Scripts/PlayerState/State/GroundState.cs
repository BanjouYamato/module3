using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : BaseState
{
    public GroundState(PlayerStateMachine state, Animator anim) : base(state, anim) { }

    public override void UpdateState(Player player)
    {
        
        if (!GameManager.Instance.Death)
        {   
            if (!GameManager.Instance.IsHit)
            {
                if (GameManager.Instance.GroundCheck)
                {
                    if (GameManager.Instance.FallingToRoll)
                        state.TransitionState(state.rollState);
                    else
                    {
                        if (GameManager.Instance.Attacking)
                            state.TransitionState(state.AttackState);
                        else
                            state.TransitionState(state.runningState);
                    }
                }
                else
                    state.TransitionState(state.airBorneState);
            }
            else
                state.TransitionState(state.hitState);
        }
        else
            state.TransitionState(state.deathState);
    }
}
