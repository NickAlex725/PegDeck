using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private PeggleManager _peggleManager;
    [SerializeField] private CardManager _cardManager;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private InfoController _infoController;
    [SerializeField] private DamageVisual _damageVisual;


    public PeggleManager PeggleManager => _peggleManager;
    public CardManager CardManager => _cardManager;
    public CameraController CameraController => _cameraController;
    public InfoController InfoController => _infoController;
    public DamageVisual DamageVisual => _damageVisual;

    [Header("UI")]
    [SerializeField] private Canvas _peggleUI;
    [SerializeField] private Canvas _cardUI;
    public TextMeshPro discardText;

    private GameFSM _stateMachine;
    public Player player;
    public Enemy enemy;
    [Space]
    public LerpUI drawPile;
    public LerpUI discardPile;
    [Space]
    public Button endTurnButton;

    [Header("Game Over")]
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;
    //public bool gameWon { get; set; } = false;
    //public bool gameLost { get; set; } = false;

    private void Awake()
    {
        _stateMachine = GetComponent<GameFSM>();
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }
    private void OnEnable()
    {
        player.OnPlayerDefeated += GameLose;
        enemy.OnEnemyDefeated += GameWin;
    }
    private void OnDisable()
    {
        player.OnPlayerDefeated -= GameLose;
        enemy.OnEnemyDefeated -= GameWin;
    }
    public void GameWin()
    {
        _winCanvas.SetActive(true);
        _loseCanvas.SetActive(false);
        _stateMachine.ChangeState(_stateMachine.OverState);
    }
    public void GameLose()
    {
        _winCanvas.SetActive(false);
        _loseCanvas.SetActive(true);
        _stateMachine.ChangeState(_stateMachine.OverState);
    }
    public void ChangeUI(bool peggleActive, bool cardActive)
    {
        _peggleUI.gameObject.SetActive(peggleActive);
        _cardUI.gameObject.SetActive(cardActive);
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
