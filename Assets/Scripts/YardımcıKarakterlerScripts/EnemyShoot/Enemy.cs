using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemys", menuName = "CustomScriptablObject/EnemysStats")]
public class Enemy : ScriptableObject
{
    [SerializeField] public float health;
    [SerializeField] private string _name;
   
    public event Action<float> OnEnemyDamaged;

    public void Damage(float damage)
    {
        if (damage < 0) return;
        health -= damage;

        OnEnemyDamaged?.Invoke(health);
    }

    public float GetHealth()
    {
        return health;
    }

    public string GetName()
    {
        return name;
    }
}
