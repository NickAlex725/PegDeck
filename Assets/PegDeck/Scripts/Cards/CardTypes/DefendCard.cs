using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCard : CardParent
{
    [SerializeField] private MovingStat movingStatPrefab;

    public override void CardAction()
    {
        if (_player.GetCurrentEnergy() >= _energyCost)
        {
            _player.AddDefenseToPlayer();
            base.CardAction();
        }
    }

    public void MoveStats()
    {
        if (movingStatPrefab != null)
        {
            MovingStat stat = Instantiate(movingStatPrefab, _player.AttackUI.transform.parent);
            RectTransform rect = stat.GetComponent<RectTransform>();
            stat.InitializeMove(textLocation.GetComponent<RectTransform>().anchoredPosition, _player.CurrentAttack);
            rect.anchoredPosition = _player.AttackUI.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
