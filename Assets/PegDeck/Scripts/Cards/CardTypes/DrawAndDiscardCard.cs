using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAndDiscardCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            _cardManager.discardMode = true;
            _cardManager.discardText.gameObject.SetActive(true);
            base.CardAction();
        }
    }
}
