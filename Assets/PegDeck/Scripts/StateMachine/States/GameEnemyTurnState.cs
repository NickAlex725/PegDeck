using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemyTurnState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameEnemyTurnState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.enemy.enemyTurnOver = false;
        
        _controller.CardManager.enemyAttackUI.text = "The enemy did " 
            + (_controller.enemy.damageAmount - _controller.player.GetCurrentDefense()) 
            +" points of damage to you!";

        _controller.enemy.DealDamage();
    }

    public override void Exit()
    {
        _controller.CardManager.enemyAttackUI.text = "";

        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if(StateDuration > 2f)
        {
            if (_controller.enemy.enemyTurnOver == true)
            {
                _stateMachine.ChangeState(_stateMachine.TransitionState);
            }
        }
        
    }
}
