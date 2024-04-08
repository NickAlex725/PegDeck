using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeggleManager : MonoBehaviour
{
    [SerializeField] private BallKillZone _killZone;
    [SerializeField] private CannonController _cannon;
    [SerializeField] private TextMeshProUGUI _attackUI;
    [SerializeField] private TextMeshProUGUI _defenseUI;

    public bool canTransition = false;

    public int attackPegsHit { get; private set; }
    public int defensePegsHit { get; private set; }

    private void OnEnable()
    {
        _killZone.OnBallTrigger += CheckTransition;
    }
    private void OnDisable()
    {
        _killZone.OnBallTrigger -= CheckTransition;
    }
    private void CheckTransition()
    {
        PrepCannon();
        if(_cannon.remainingBalls == 0)
        {
            canTransition = true;
        }
    }
    public void AddAttack()
    {
        attackPegsHit++;
        _attackUI.text = attackPegsHit.ToString();
    }

    public void AddDefense()
    {
        defensePegsHit++;
        _defenseUI.text = defensePegsHit.ToString();
    }

    public void ResetPegsHit()
    {
        attackPegsHit = 0;
        _attackUI.text = attackPegsHit.ToString();
        defensePegsHit = 0;
        _defenseUI.text = defensePegsHit.ToString();
    }

    public void PrepCannon()
    {
        if(_cannon != null )
        {
            _cannon.LaunchReady();
        }
    }
    public void ResetCannon()
    {
        _cannon.ResetCannon();
    }
}
