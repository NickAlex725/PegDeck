using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCard : CardParent
{
    public override void CardAction()
    {
        _player.AddDefense(_defenseStat);
    }
}
