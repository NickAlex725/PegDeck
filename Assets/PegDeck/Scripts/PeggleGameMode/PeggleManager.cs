using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeggleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackUI;
    [SerializeField] private TextMeshProUGUI _defenseUI;

    private int _attackPegsHit;
    private int _defensePegsHit;

    public void AddAttack()
    {
        _attackPegsHit++;
        _attackUI.text = _attackPegsHit.ToString();
    }

    public void AddDefense()
    {
        _defensePegsHit++;
        _defenseUI.text = _defensePegsHit.ToString();
    }

}
