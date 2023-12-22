using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent<int,int> _healthChanged;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;

        _healthChanged?.Invoke(_health, _maxHealth);
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        _healthChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            _health = 0;
        }

        _healthChanged?.Invoke(_health, _maxHealth);
    }
}
