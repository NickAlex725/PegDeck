using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damagePreview;
    [SerializeField] private int[] _damagePool;

    private Health _health;
    private Player _player;
    
    public int damageAmount { get; private set; }

    public bool enemyTurnOver = false;

    public Action OnEnemyDefeated = delegate { };

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _health = GetComponent<Health>();
        _healthSlider.maxValue = _health.GetMaxHealth();
        _healthSlider.value = _healthSlider.maxValue;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        _health.TakeDamage(damage);
        _healthSlider.value = _health._currentHealth;
        _healthText.text = _health._currentHealth + "/" + _health.GetMaxHealth();

        if(_health._currentHealth <= 0)
        {
            OnEnemyDefeated?.Invoke();
        }
    }

    public void DealDamage()
    {
        _player.TakeDamage(damageAmount);
        enemyTurnOver = true;
    }

    public void CalcDamage()
    {
        damageAmount = _damagePool[UnityEngine.Random.Range(0, _damagePool.Length)];
        _damagePreview.text = damageAmount.ToString();
    }

    public void UpdateHealthUI()
    {
        _healthSlider.value = _health._currentHealth;
        _healthText.text = _health._currentHealth + "/" + _health.GetMaxHealth();
    }
}
