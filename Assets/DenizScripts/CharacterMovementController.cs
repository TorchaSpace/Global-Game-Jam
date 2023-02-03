using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    
    private Rigidbody _rb;
    

    private void OnEnable()
    {
        inputManager.OnKeyboardInputGiven += Move;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Move(Vector3 obj)
    {
        _rb.MovePosition(transform.position + obj*speed);    
    }
    
    
    
}
