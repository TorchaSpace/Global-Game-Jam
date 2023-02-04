using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Projectile : Damager
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        StartCoroutine(Kill());
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void Fire(Vector3 direction)
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.LookAt(direction);
        Vector3 d = direction - transform.position;
        
        _rigidbody.AddForce(d.normalized*speed,ForceMode.Impulse);
    }
    
    
    

}
