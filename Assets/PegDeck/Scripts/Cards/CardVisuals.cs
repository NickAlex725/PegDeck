using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardVisuals : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _energyText;
    [SerializeField] private TextMeshProUGUI _statsText;

    private CardParent _card;
    private Player _player;

    private void Awake()
    {
        _card = GetComponent<CardParent>();
        _player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        UpdateVisuals();
    }

    private void Update()
    {
        
    }

    private void UpdateVisuals()
    {
        if(_card != null)
        {
            if(_energyText != null) _energyText.text = _card.EnergyCost.ToString();
        }
        if(_player != null)
        {
            if(_statsText != null)
            {
                AttackCard attack = _card.GetComponentInParent<AttackCard>();
                DefendCard defend = _card.GetComponentInParent<DefendCard>();
                EnergyCard energy = _card.GetComponentInParent<EnergyCard>();

                if(attack != null)
                {
                    _statsText.text = _player.GetCurrentAttack().ToString();
                }
                if(defend != null)
                {
                    _statsText.text = _player.GetDefenseStatOnCard().ToString();
                }
                if(energy != null)
                {
                    _statsText.text = energy.EnergyGain.ToString();
                }
            }
        }
    }
}
