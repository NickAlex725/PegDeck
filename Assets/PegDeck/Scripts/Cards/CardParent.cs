using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardParent : MonoBehaviour
{
    [SerializeField] protected Player _player;

    protected int _attackStat;
    protected int _defenseStat;
    protected int _energyGain;

    public abstract void CardAction();

}
