using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthSystem : MonoBehaviour
{
    public Action<float> OnHealthChanged;
    public Action OnPlayerDied;
    public float maxHealth;
    private float _currentHealth;


    private void Awake()
    {
        _currentHealth = maxHealth;
    }


    public void Damage(float x)
    {
        float damagedHealth = _currentHealth - x;
        if (damagedHealth <= 0)
        {
            OnPlayerDied?.Invoke();
            //Oyunu kaybet
            return;
        }

        _currentHealth = damagedHealth;
        OnHealthChanged?.Invoke(_currentHealth);
    }
    
    
}
