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

    private void Awake()
    {
        _card = GetComponent<CardParent>();
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
    }
}
