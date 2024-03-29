using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            _player.AddEnergy(_energyGain);
            base.CardAction();
        }
    }
}
