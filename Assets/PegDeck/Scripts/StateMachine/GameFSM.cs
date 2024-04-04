using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    //state variables
    public GameSetupState SetupState;
    public GamePeggeState PeggleState;
    public GameTransitionState TransitionState;
    public GamePlayerTurnState PlayerTurn;
    public GameEnemyTurnState EnemyTurn;

    private void Awake()
    {
        _controller = GetComponent<GameController>();

        SetupState = new GameSetupState(this, _controller);
        PeggleState = new GamePeggeState(this, _controller);
        TransitionState = new GameTransitionState(this, _controller);
        PlayerTurn = new GamePlayerTurnState(this, _controller);
        EnemyTurn = new GameEnemyTurnState(this, _controller);
    }
    private void Start()
    {
        ChangeState(SetupState);
    }
}
