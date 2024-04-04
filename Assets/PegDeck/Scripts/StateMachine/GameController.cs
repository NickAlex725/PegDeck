using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private PeggleManager _peggleManager;
    [SerializeField] private CardManager _cardManager;
    [SerializeField] private CameraController _cameraController;

    public PeggleManager PeggleManager => _peggleManager;
    public CardManager CardManager => _cardManager;
    public CameraController CameraController => _cameraController;

    [Header("UI")]
    [SerializeField] private Canvas _peggleUI;
    [SerializeField] private Canvas _cardUI;

    private GameFSM _stateMachine;

    private void Awake()
    {
        _stateMachine = GetComponent<GameFSM>();
    }
    public void ChangeUI(bool peggleActive, bool cardActive)
    {
        _peggleUI.gameObject.SetActive(peggleActive);
        _cardUI.gameObject.SetActive(cardActive);
        Debug.Log("UI changed");
    }
    public void Transition()
    {
        _stateMachine.ChangeState(_stateMachine.TransitionState);
    }
    public void TransitionPlayerTurn()
    {
        _stateMachine.ChangeState(_stateMachine.PlayerTurn);
    }
}
