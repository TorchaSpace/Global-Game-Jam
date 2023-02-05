using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthSystem : MonoBehaviour
{
    public Action<float> OnHealthChanged;
    public Action OnPlayerDied;
    public float maxHealth;
    private float _currentHealth;

    public Slider healthBar;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void Damage(float x)
    {
        float damagedHealth = _currentHealth + x;
        if (damagedHealth >= 100)
        {
            OnPlayerDied?.Invoke();
            RestartGame.restartGame.Restart();
            return;
        }

        _currentHealth = damagedHealth;
        OnHealthChanged?.Invoke(_currentHealth);
    }
    
    
}
