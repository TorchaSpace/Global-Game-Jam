using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterHealthSystem : MonoBehaviour
{
    public Action<float> OnHealthChanged;
    public Action OnPlayerDied;
    public float maxHealth;
    private float _currentHealth;

    public Slider healthBar;

    private void Awake()
    {
        _currentHealth = 0;
    }

    public void Damage(float x)
    {
        float damagedHealth = _currentHealth + x;
        if (damagedHealth >= 100)
        {
            OnPlayerDied?.Invoke();
            SceneManager.LoadScene("DeathScreen");
            return;
        }

        _currentHealth = damagedHealth;
        healthBar.value = _currentHealth;
        OnHealthChanged?.Invoke(_currentHealth);
    }
    
    
}
