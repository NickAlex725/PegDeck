using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardParent
{
    public override void CardAction()
    {
        _player.AddAttack(_attackStat);
    }
}
