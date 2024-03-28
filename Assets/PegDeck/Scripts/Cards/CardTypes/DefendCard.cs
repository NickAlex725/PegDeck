using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            base.CardAction();
            _player.AddDefense(_defenseGain);
            DestoryCard();
        }
    }
}
