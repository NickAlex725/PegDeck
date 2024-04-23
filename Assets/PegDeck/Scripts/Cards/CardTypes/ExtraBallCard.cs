using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBallCard : CardParent
{
    public override void CardAction()
    {
        base.CardAction();
        _peggleManager.GainExtraBall();
    }
}
