using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackPeg : Peg
{
    public override void OnPegHit()
    {
        base.OnPegHit();
        _peggleManager.AddAttack();

        StartCoroutine(DisablePeg());
    }
}
