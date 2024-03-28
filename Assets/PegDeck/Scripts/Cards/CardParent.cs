using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardParent : MonoBehaviour
{
    [SerializeField] protected int _energyCost;

    protected Player _player;
    protected int _attackStat;
    protected int _defenseGain = 10; //temp value, will be determined by peggle game later
    protected int _energyGain = 2; //temp value, will be determined by peggle game later

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public virtual void CardAction()
    {
        _player.UseEnergy(_energyCost);
        //add base func here (animations, sound, ect)
    }

    public void DestoryCard()
    {
        Destroy(gameObject);
    }
}
