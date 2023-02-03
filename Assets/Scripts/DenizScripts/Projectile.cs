using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Damager
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    
    public void Fire(Vector3 direction)
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.AddForce(direction.normalized*speed,ForceMode.Impulse);
    }
    
}
