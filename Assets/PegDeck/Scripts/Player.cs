using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxEnergy;

    [Header("Player UI")]
    [SerializeField] private TextMeshProUGUI _attackUI;
    [SerializeField] private TextMeshProUGUI _defenseUI;
    [SerializeField] private TextMeshProUGUI _energyUI;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;

    private int _defenseStatOnCard;

    //stats used for card actions
    private int _currentAttack;
    private int _currentDefense;
    private int _currentEnergy;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _currentEnergy = _maxEnergy;
        _healthSlider.maxValue = _health.GetMaxHealth();
        _healthSlider.value = _healthSlider.maxValue;
    }

    #region public methods to adjust players stats
    public void AddAttack(int amount)
    {
        _currentAttack += amount;
        _attackUI.text = "Attack:" + _currentAttack;
    }

    public void AddDefense(int amount)
    {
        _defenseStatOnCard += amount;
    }

    public void AddDefenseToPlayer()
    {
        _currentDefense += _defenseStatOnCard;
        _defenseUI.text = "Defense:" + _currentDefense;
    }

    public void AddEnergy(int amount)
    {
        //current energy may be show higher than max energy, this is intentional
        _currentEnergy += amount;
        _energyUI.text = "Energy:" + _currentEnergy + "/" + _maxEnergy;
    }

    public void UseEnergy(int amount)
    {
        _currentEnergy -= amount;
        _energyUI.text = "Energy:" + _currentEnergy + "/" + _maxEnergy;
    }

    public void ResetStats()
    {
        _currentAttack = 0;
        _attackUI.text = "Attack:" + _currentAttack;
        _defenseStatOnCard = 0;
        _currentDefense = 0;
        _defenseUI.text = "Defense:" + _currentDefense;
        _currentEnergy = _maxEnergy;
        _energyUI.text = "Energy:" + _currentEnergy + "/" + _maxEnergy;
    }
    #endregion 

    public void TakeDamage(int damageAmount)
    {
        if(damageAmount > _currentDefense)
        {
            _health.TakeDamage(damageAmount - _currentDefense);
            _currentDefense = 0;
        }
        else
        {
            _currentDefense -= damageAmount;
        }
        _healthSlider.value = _health._currentHealth;
        _healthText.text = _health._currentHealth + "/" + _health.GetMaxHealth();
    }

    public void DealDamage(Enemy target)
    {
        target.TakeDamage(_currentAttack);
    }

    public int GetCurrentEnergy()
    {
        return _currentEnergy;
    }
}
