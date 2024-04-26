using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardParent
{
    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            _player.DealDamage(_target);

            //sfx
            AudioSFX.Instance.PlaySoundEffect(SFXType.EnemyHit);

            //enemy hit animation
            _target.DoHurtAnimation();

            base.CardAction();
        }
    }
}
