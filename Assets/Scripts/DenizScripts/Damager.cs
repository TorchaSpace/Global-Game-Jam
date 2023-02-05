using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(ColliderActivator());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBehaviour enemyBehaviour = other.GetComponent<EnemyBehaviour>();
        if (enemyBehaviour)
        {
            enemyBehaviour.Damage(damageAmount);
        }
               
    }
    
    IEnumerator ColliderActivator()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

}
