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

        _controller.InfoController.UpdatePanel(InfoState.EnemyText);
    }

    public override void Exit()
    {
        _controller.CardManager.enemyAttackUI.text = "";
        
        //boards
        _controller.PeggleManager.ResetPegs();
        _controller.PeggleManager.SelectBoard();


        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if (StateDuration > 2f && _controller.enemy.enemyTurnOver == false)
        {
            //do damage
            int damage = _controller.enemy.damageAmount - _controller.player.GetCurrentDefense();

            _controller.CardManager.enemyAttackUI.text = "The enemy did "
            + Mathf.Clamp(damage, 0, _controller.enemy.damageAmount) + " points of damage to you!";

            //animation
            _controller.enemy.DoAttackAnimation();

            //sfx
            if (damage > 0)
            {
                AudioSFX.Instance.PlaySoundEffect(SFXType.PlayerHit);
            }

            _controller.enemy.DealDamage();
        }
        if(StateDuration > 4f && _controller.enemy.enemyTurnOver == true)
        {
            //sfx
            AudioSFX.Instance.PlaySoundEffect(SFXType.EnterPeggleState);

            //change state
            _stateMachine.ChangeState(_stateMachine.TransitionState);
        }

    }
}
