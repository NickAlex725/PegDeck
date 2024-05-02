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
    [SerializeField] private TextMeshProUGUI _energyUI;
    [SerializeField] private List<Transform> _pegBoards;

    public bool canTransition = false;

    public int attackPegsHit { get; private set; }
    public int defensePegsHit { get; private set; }
    public int energyPegsHit { get; private set; }

    Transform _currentBoard;
    List<GameObject> _pegsList = new List<GameObject>();

    private void OnEnable()
    {
        _killZone.OnBallTrigger += CheckTransition;
    }
    private void OnDisable()
    {
        _killZone.OnBallTrigger -= CheckTransition;
    }

    public void SelectBoard()
    {
        int rand = Random.Range(0, _pegBoards.Count);

        for (int i = 0; i < _pegBoards.Count; i++)
        {
            if(i == rand)
            {
                _currentBoard = _pegBoards[i];
                _currentBoard.gameObject.SetActive(true);
            }
            else
            {
                _pegBoards[i].gameObject.SetActive(false);
            }

        }
        _currentBoard = _pegBoards[rand];

        StorePegs();
    }
    public void SelectBoard(int selectedBoard)
    {
        _currentBoard = _pegBoards[selectedBoard];

        StorePegs();
    }
    public void StorePegs()
    {
        _pegsList.Clear();

        if(_currentBoard != null)
        {
            foreach (Transform peg in _currentBoard)
            {
                _pegsList.Add(peg.gameObject);
            }

            ResetPegs();
        }
        else
        {
            Debug.LogError("Missing peg board.");
        }
    }
    public void ResetPegs()
    {
        if(_pegsList.Count > 0)
        {
            foreach(GameObject peg in _pegsList)
            {
                peg.SetActive(true);
            }
        }
    }

    private void CheckTransition()
    {
        PrepCannon();
        if(_cannon._remainingBalls == 0)
        {
            _cannon._extraBalls = 0;

            StartCoroutine(DelayTransition(1.5f));
        }
    }
    public void AddAttack()
    {
        attackPegsHit++;
        //_attackUI.text = attackPegsHit.ToString();
        RefreshUI();
    }

    public void AddDefense()
    {
        defensePegsHit++;
        //_defenseUI.text = defensePegsHit.ToString();
        RefreshUI();
    }

    public void AddEnergy()
    {
        energyPegsHit++;
        //_energyUI.text = energyPegsHit.ToString();
        RefreshUI();
    }

    public void RefreshUI()
    {
        if(_attackUI != null) _attackUI.text = attackPegsHit.ToString();
        if(_defenseUI != null) _defenseUI.text = defensePegsHit.ToString();
        if(_energyUI != null) _energyUI.text = energyPegsHit.ToString();
    }

    public void ResetPegsHit()
    {
        attackPegsHit = 0;
        _attackUI.text = attackPegsHit.ToString();
        defensePegsHit = 0;
        _defenseUI.text = defensePegsHit.ToString();
        energyPegsHit = 0;
        _energyUI.text = energyPegsHit.ToString();

        ResetPegs();
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
    public void GainExtraBall()
    {
        _cannon.GainExtraBall();
    }

    IEnumerator DelayTransition(float delay)
    {
        yield return new WaitForSeconds(delay);

        canTransition = true;
    }
}
