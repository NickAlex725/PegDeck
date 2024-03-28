using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            base.CardAction();
            //once enemy is made: Take in the target as a parameter and
            //call its take damage function
            DestoryCard();
        }
    }
}
