using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBallCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            _peggleManager.GainExtraBall(); base.CardAction();
            base.CardAction();
        }
    }
}
