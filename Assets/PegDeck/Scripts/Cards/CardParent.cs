using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardParent : MonoBehaviour
{
    [SerializeField] protected int _energyCost;
    public int EnergyCost => _energyCost;

    protected CardManager _cardManager;
    protected Player _player;
    protected Enemy _target;
    protected int _attackGain;
    protected int _energyGain;


    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _cardManager = FindObjectOfType<CardManager>();
        _target = FindObjectOfType<Enemy>();
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
