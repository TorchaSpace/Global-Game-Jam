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
        Vector3 lerpedPos = Vector3.Lerp(transform.forward,obj,rotSpeed);
        lerpedPos.y = 0;
        transform.DOKill();
        transform.DOLookAt(lerpedPos, 0.1f);
    }
    
    
    
    
    
    
}
