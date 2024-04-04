using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePeggeState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePeggeState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.ChangeUI(true, false);

        _controller.PeggleManager.canTransition = false;

        _controller.PeggleManager.ResetCannon();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if(_controller.PeggleManager.canTransition == true)
        {
            _stateMachine.ChangeState(_stateMachine.TransitionState);
        }
    }
}
