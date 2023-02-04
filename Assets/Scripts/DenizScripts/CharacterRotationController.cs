using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterRotationController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float rotSpeed = 0.5f;
    private void OnEnable()
    {
        inputManager.OnMouseMove += RotateCharacter;
    }
    
    
    

    private void RotateCharacter(Vector3 obj)
    {
        if (Vector3.Distance(transform.position,obj) < 10) return;
        obj.y = 0;
        transform.DOKill();
        transform.DOLookAt(obj, rotSpeed).SetUpdate(false);
    }
    
    
    
    
    
    
}
