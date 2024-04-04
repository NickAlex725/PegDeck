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

    private int _attackPegsHit;
    private int _defensePegsHit;

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
        _attackPegsHit++;
        _attackUI.text = _attackPegsHit.ToString();
    }

    public void AddDefense()
    {
        _defensePegsHit++;
        _defenseUI.text = _defensePegsHit.ToString();
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
