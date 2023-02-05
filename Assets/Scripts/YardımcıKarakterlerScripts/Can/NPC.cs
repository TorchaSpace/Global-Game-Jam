using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    [SerializeField] private Slider healthSlider;
    
    private Vector3 _toGoPos;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        NPCManager.instance.AddArcher(this);
        _toGoPos = NPCManager.instance.GetRandomPos();
    }

    private void OnDisable()
    {
        NPCManager.instance.RemoveArcher(this);
    }



    public void Damage(float x)
    {
        float damagedHealth = _currentHealth - x;
        if (damagedHealth <= 0)
        {
            Die();
            return;
        }

        _currentHealth = damagedHealth;
        healthSlider.value = _currentHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
        NPCManager.npcCount--;
    }
    
    
}
