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
        _controller.PeggleManager.ResetPegsHit();
        _controller.PeggleManager.ResetCannon();

        _controller.player.ResetStats();
    }

    public override void Exit()
    {
        base.Exit();

        //add stats to player
        _controller.player.AddAttack(_controller.PeggleManager.attackPegsHit);
        _controller.player.AddDefense(_controller.PeggleManager.defensePegsHit);
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
