using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCard : CardParent
{
    public override void CardAction()
    {
        _player.AddEnergy(_energyGain);
    }
}
