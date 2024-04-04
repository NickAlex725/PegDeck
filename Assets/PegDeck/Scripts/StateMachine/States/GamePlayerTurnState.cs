using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerTurnState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayerTurnState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.ChangeUI(false, true);

        _controller.CardManager.playerTurnOver = false;
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

        if(_controller.CardManager.playerTurnOver == true)
        {
            _stateMachine.ChangeState(_stateMachine.EnemyTurn);
        }
    }
}
