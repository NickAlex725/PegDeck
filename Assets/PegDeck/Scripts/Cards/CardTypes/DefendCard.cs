using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            _player.AddDefenseToPlayer();
            base.CardAction();
        }
    }
}
