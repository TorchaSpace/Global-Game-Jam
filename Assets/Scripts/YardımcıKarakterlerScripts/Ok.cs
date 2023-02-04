using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok : MonoBehaviour
{
    public float speed;
    private Transform enemy;
    private Vector3 target;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").transform;
        target = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
    }

    private void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
