using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    public event UnityAction<int,int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;

        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            _health = 0;
        }

        HealthChanged?.Invoke(_health, _maxHealth);
    }
}
