using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTransitionState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameTransitionState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.CameraController.OnTargetPosition += TransitionComplete;

        _controller.ChangeUI(false, false);

        if (_controller.CameraController.CheckIfOnPeggleState()) _controller.CameraController.SwapToCard();
        else _controller.CameraController.SwapToPeggle();
    }

    public override void Exit()
    {
        base.Exit();

        _controller.CameraController.OnTargetPosition -= TransitionComplete;
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }


    public void TransitionComplete(bool peggPosition)
    {
        //Debug.LogFormat("TransitionComplete({0})", peggPosition);
        if(peggPosition == false)
        {
            _stateMachine.ChangeState(_stateMachine.PlayerTurn);
        }
        else
        {
            _stateMachine.ChangeState(_stateMachine.PeggleState);
        }
    }
}
