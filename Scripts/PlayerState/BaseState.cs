using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IState
{
    protected PlayerStateMachine state;
    protected Animator anim;
    public BaseState(PlayerStateMachine state, Animator anim)
    {
        this.state = state;
        this.anim = anim;
    }

    public virtual void EnterState(Player player) { }
    public virtual void ExitState(Player player) { }
    public virtual void UpdateState(Player player) { }
}
