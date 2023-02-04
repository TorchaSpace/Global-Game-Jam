using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int health = 100;
    public int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            health -= damage;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
