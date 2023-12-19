using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    public event Action<float> HealthChanged;
    public event Action Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void AddHealth(float health)
    {
        float currentHhealth = Math.Clamp(_health + health, _health, _maxHealth);

        if (currentHhealth != _health)
        {
            _health = currentHhealth;
            HealthChanged?.Invoke(_health);
        }
    }

    public void TakeDamage(float damage)
    {
        _health = Math.Clamp(_health - damage, 0, _health);
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}