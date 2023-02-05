using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBetweenAttacks = 0.3f;
    private float timePassed = 1000;

    [SerializeField] private Transform handPos;
    [SerializeField] private GameObject currentWeapon;
    
    private void OnEnable()
    {
        inputManager.OnMouseClick += Fire;
        
    }

    private void OnDisable()
    {
        inputManager.OnMouseClick -= Fire;
    }

    private void Start()
    {
        currentWeapon = Instantiate(weaponHolder.weaponPrefab, handPos);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    private void Fire()
    {
        if (timePassed < timeBetweenAttacks)
        {
            Damager.damageAmount = 0;
            return;
        }
        Damager.damageAmount = 5;



        animator.SetTrigger("attack");
        weaponHolder.Fire(transform.forward);
        timePassed = 0;
    }
    
    
    
}


