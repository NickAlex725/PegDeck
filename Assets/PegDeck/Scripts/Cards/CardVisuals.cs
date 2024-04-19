using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardVisuals : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _energyText;
    [SerializeField] private TextMeshProUGUI _statsText;

    [Header("Sprites")]
    [SerializeField] private Sprite _attackFireBall;
    [SerializeField] private Sprite _attackFireBlast;
    [SerializeField] private Sprite _attackFireSword;
    [SerializeField] private Sprite _attackLightning;
    [SerializeField] private Sprite _energyPlus;
    [SerializeField] private Sprite _defenseShield;

    private CardParent _card;
    private Player _player;
    private SpriteRenderer _cardRenderer;
    private int _randIndex;

    private void Awake()
    {
        _card = GetComponent<CardParent>();
        _player = FindObjectOfType<Player>();
        _cardRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        _card.OnCardUpdate += UpdateVisuals;
    }
    private void OnDisable()
    {
        _card.OnCardUpdate -= UpdateVisuals;
    }
    private void Start()
    {
        _randIndex = Random.Range(0, 4);

        UpdateVisuals();
    }

    private void Update()
    {
        
    }

    private void UpdateVisuals()
    {
        //Debug.Log("UpdateVisuals()");

        if(_card != null)
        {
            if(_energyText != null) _energyText.text = _card.EnergyCost.ToString();
        }
        if (_cardRenderer != null)
        {
            //Debug.Log("Update Card Renderer");
            if (_card.CardType == CardType.Attack)
            {
                if (_randIndex == 0)
                {
                    _cardRenderer.sprite = _attackFireBall;
                }
                else if (_randIndex == 1)
                {
                    _cardRenderer.sprite = _attackFireBlast;
                }
                else if (_randIndex == 2)
                {
                    _cardRenderer.sprite = _attackFireSword;
                }
                else
                {
                    _cardRenderer.sprite = _attackLightning;
                }
            }
            else if (_card.CardType == CardType.Defense)
            {
                _cardRenderer.sprite = _defenseShield;
            }
            else if (_card.CardType == CardType.Energy)
            {
                _cardRenderer.sprite = _energyPlus;
            }
        }
        if (_player != null)
        {
            if(_statsText != null)
            {
                if (_card.CardType == CardType.Attack)
                {
                    _statsText.text = _player.GetCurrentAttack().ToString();
                }
                else if (_card.CardType == CardType.Defense)
                {
                    _statsText.text = _player.GetDefenseStatOnCard().ToString();
                }
                else if (_card.CardType == CardType.Energy)
                {
                    EnergyCard energy = _card.GetComponentInParent<EnergyCard>();
                    _statsText.text = energy.EnergyGain.ToString();
                }
            }
        }
        
    }
}
