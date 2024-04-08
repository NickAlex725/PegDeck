using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damagePreview;
    [SerializeField] private int[] _damagePool;

    private Health _health;
    private Player _player;
    private int _damageAmount;

    public bool enemyTurnOver = false;

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
    }

    public void DealDamage()
    {
        _player.TakeDamage(_damageAmount);
        enemyTurnOver = true;
    }

    public void CalcDamage()
    {
        _damageAmount = _damagePool[Random.Range(0, _damagePool.Length)];
        _damagePreview.text = _damageAmount.ToString();
    }
}
