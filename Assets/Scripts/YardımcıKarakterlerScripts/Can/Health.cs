using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    int currentHealth;
    int currentMaxHealth;

    public int health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return currentMaxHealth;
        }
        set
        {
            currentMaxHealth = value; 
        }
    }

    public Health(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        if(currentHealth < currentMaxHealth)
        {
            currentHealth -= damageAmount;
        }
    }

    public void Regen(int regenAmount)
    {
        if(currentHealth < currentMaxHealth)
        {
            currentHealth += regenAmount;
        }
        if(currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }
}
