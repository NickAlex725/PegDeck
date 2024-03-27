using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxEnergy;

    [Header("Player UI")]
    [SerializeField] private TextMeshProUGUI _attackUI;
    [SerializeField] private TextMeshProUGUI _defenseUI;
    [SerializeField] private TextMeshProUGUI _energyUI;

    private int _currentAttack;
    private int _currentDefense;
    private int _currentEnergy;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    //public methods to adjust players stats
    #region
    public void AddAttack(int amount)
    {
        _currentAttack += amount;
        _attackUI.text = "Attack: " + _currentAttack;
    }

    public void AddDefense(int amount)
    {
        _currentDefense += amount;
        _defenseUI.text = "Defense: " + _currentDefense;
    }

    public void AddEnergy(int amount)
    {
        //current energy may be show higher than max energy, this is intentional
        _currentEnergy += amount;
        _energyUI.text = "Energy: " + _currentEnergy + " / " + _maxEnergy;
    }

    public void UseEnergy(int amount)
    {
        _currentEnergy -= amount;
        _energyUI.text = "Energy: " + _currentEnergy + " / " + _maxEnergy;
    }
    #endregion 

    public void TakeDamage(int damageAmount)
    {
        if(damageAmount > _currentDefense)
        {
            TakeDamage(damageAmount - _currentDefense);
            _currentDefense = 0;
        }
        else
        {
            _currentDefense -= damageAmount;
        }
    }

    public void DealDamage()
    {
        //once enemy is made: Take in the target as a parameter and
        //call its take damage function
    }

    public int GetCurrentEnergy()
    {
        return _currentEnergy;
    }
}
