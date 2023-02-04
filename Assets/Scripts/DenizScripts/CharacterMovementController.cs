using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    
    private Rigidbody _rb;

    private bool _isMoving = false;
    

    private void OnEnable()
    {
        inputManager.OnKeyboardInputGiven += Move;
        inputManager.OnKeyboardInputReleased += StopMoving;
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void StopMoving()
    {
        if (_isMoving)
        {
            animator.SetBool("moving",false);
            _isMoving = false;
        }
    }

    

    private void Move(Vector3 obj)
    {
        _rb.MovePosition( transform.position+ obj*speed);
        if (!_isMoving)
        {
            animator.SetBool("moving",true);
            _isMoving = true;
        }
    }
    
    
    
}
