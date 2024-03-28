using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardParent : MonoBehaviour
{
    [SerializeField] protected int _energyCost;

    protected CardManager _cardManager;
    protected Player _player;
    protected int _attackStat;
    protected int _defenseGain = 10; //temp value, will be determined by peggle game later
    protected int _energyGain = 2; //temp value, will be determined by peggle game later

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _cardManager = FindObjectOfType<CardManager>();
    }

    public virtual void CardAction()
    {
        _player.UseEnergy(_energyCost);
        _cardManager.DiscardCard(this);
        //add base func here (animations, sound, ect)
        //DestoryCard();
    }

    public void HideCard()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    public void UnhideCard()
    {
        gameObject.SetActive(true);
    }
}
