using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    private void OnTriggerEnter(Collider other)
    {
        EnemyBehaviour enemyBehaviour = other.GetComponent<EnemyBehaviour>();
        if (enemyBehaviour)
        {
            enemyBehaviour.Damage(damageAmount);
            Destroy(gameObject);    
        }
        
        
        
    }
    
    
    
}
