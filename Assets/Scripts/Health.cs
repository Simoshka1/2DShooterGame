using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int Value { get; private set; }

    public int MaxHealth => _maxHealth;

    public Action HealthChanged;
    public Action Killed;

    private void Start()
    {
        Value = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Value -= damage;
        HealthChanged?.Invoke();
        if (Value <= 0)
        {
            Killed?.Invoke();
            Destroy(gameObject);
        }
    }

    public void Heal(int bonusHealth)
    {
        Value = Value + bonusHealth;
        if (Value > _maxHealth)
        {
            Value = _maxHealth;
        }
    }
}
