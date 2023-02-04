using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private CharacterHealthSystem characterHealthSystem;

    private void OnEnable()
    {
        characterHealthSystem.OnHealthChanged += SetHealth;
        
    }
    private void OnDisable()
    {
        characterHealthSystem.OnHealthChanged += SetHealth;
    }

    private void SetHealth(float x)
    {
        healthSlider.value = x;
    }
    
    
    
    
}
