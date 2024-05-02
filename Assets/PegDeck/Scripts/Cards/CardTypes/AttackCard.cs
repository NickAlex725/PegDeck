using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardParent
{
    [SerializeField] private MovingStat movingStatPrefab;
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

    public void MoveStats()
    {
        Debug.LogWarning("MoveStats");
        if(movingStatPrefab != null)
        {
            MovingStat stat = Instantiate(movingStatPrefab, _player.AttackUI.transform.parent);
            RectTransform rect = stat.GetComponent<RectTransform>();
            stat.InitializeMove(textLocation.GetComponent<RectTransform>().anchoredPosition, _player.CurrentAttack);
            //rect.anchoredPosition = _player.AttackUI.GetComponent<RectTransform>().anchoredPosition;

            Vector3 vPos = Camera.main.WorldToViewportPoint(_player.AttackUI.transform.position);
            rect.anchoredPosition = vPos;
        }
    }
}
