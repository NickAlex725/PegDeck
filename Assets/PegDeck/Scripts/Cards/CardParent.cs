using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardParent : MonoBehaviour
{
    [SerializeField] protected int _energyCost;

    protected Player _player;
    protected int _attackStat;
    protected int _defenseStat;
    protected int _energyGain;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public virtual void CardAction()
    {
        //add base func here (animations, sound, ect)
    }
}
