using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event Action<float, float> OnHealthChange;
    public event Action OnDie;

    [SerializeField] private GameStateManager _gameStateManager;

    private void Start()
    {
        SetHealth(_maxHealth);
    }
    public void TakeDamage(float value)
    {
        float newHealth = _currentHealth - value;
        newHealth = Mathf.Max(newHealth, 0f);
        SetHealth(newHealth);
        if (newHealth == 0)
        {
            Die();
        }
    }

    public void SetHealth(float value)
    {
        _currentHealth = value;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    void Die()
    {
        OnDie?.Invoke();
        Debug.Log("Die");
        _gameStateManager.SetLose();
    }
}
