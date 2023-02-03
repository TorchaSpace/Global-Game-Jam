using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform enemy;
    private Vector2 target;

    public EnemyDamage enemyDamage;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").transform;

        target = new Vector2(enemy.position.x, enemy.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            DestroyProjectile();
            enemyDamage.TakeDamageFromHelper();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
