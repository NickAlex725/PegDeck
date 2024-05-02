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
        //_controller.enemy.CalcDamage();
        _controller.CardManager.playerTurnOver = false;
        _controller.CardManager.DrawCards(_controller.player._drawAmount);

        _controller.player.UpdateHealthUI();
        _controller.enemy.UpdateHealthUI();

        _controller.InfoController.UpdatePanel(InfoState.PlayerText);

        //move piles
        _controller.drawPile.atStart = false;
        _controller.discardPile.atStart = false;

        //enable button
        _controller.endTurnButton.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        //move piles
        _controller.drawPile.atStart = true;
        _controller.discardPile.atStart = true;

        //disable button
        _controller.endTurnButton.gameObject.SetActive(false);
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
            //sfx
            AudioSFX.Instance.PlaySoundEffect(SFXType.EnterEnemyState);

            _stateMachine.ChangeState(_stateMachine.EnemyTurn);
        }
    }
}
