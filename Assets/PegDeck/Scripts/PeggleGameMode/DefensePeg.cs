using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePeg : Peg
{
    public override void OnPegHit()
    {
        base.OnPegHit();
        _peggleManager.AddDefense();
    }
}
