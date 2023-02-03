using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private WeaponHolder weaponHolder;
    

    private void OnEnable()
    {
        inputManager.OnMouseClick += Fire;
        
    }

    private void OnDisable()
    {
        inputManager.OnMouseClick -= Fire;
    }

    private void Fire()
    {
        weaponHolder.Fire(transform.forward);
    }
    
    
    
}


