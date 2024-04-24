using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPeg : Peg
{
    public override void OnPegHit()
    {
        base.OnPegHit();
        _peggleManager.AddEnergy();

        StartCoroutine(DisablePeg());
    }
}
