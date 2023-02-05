using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    [SerializeField] private GameObject _target;
    [SerializeField] private float targetCheckCooldown;
    [SerializeField] private float minTargetingDistance;
    [SerializeField] private float attackingDistance = 2;
    private GameObject _currentTarget;
    private Vector3 _direction;
    [SerializeField] private float _movementSpeed = 5;

    [SerializeField] private Animator animator;

    private GameObject _tree;
    private bool _isWalking;
    private bool _isAttacking;
    [SerializeField] private float damage;

    [SerializeField] private float health = 10;
    public void Damage(float x)
    {
        float damagedHealth = health - x;
        if (damagedHealth <= 0)
        {
            Die();
            return;
        }
        health = damagedHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _tree = GameObject.FindGameObjectWithTag("Tree");
        targets.Add(GameObject.FindGameObjectWithTag("Player"));
        targets.Add(_tree);
        StartCoroutine(Timer());
    }
    private void Update()
    {
        StateChecker();
    }

    public void GetTarget(GameObject target)
    {
        targets.Add(target);
    }

    private void SetTarget()
    {
        
        float distance = Mathf.Infinity;
        float newDistance;

        for (int i = targets.Count-1; i >= 0; i--)
        {
            if (!targets[i])
            {
                targets.RemoveAt(i);
                continue;
            }
            newDistance = Vector3.Distance(targets[i].transform.position, transform.position);
            if (newDistance < distance)
            {
                distance = newDistance;
                _currentTarget = targets[i];
            }
        }
        
        _target = _currentTarget;
        _isWalking = false;
    }

    private void StateChecker()
    {
        if (!_target)
        {
            SetTarget();
        }
        else
        {
            Vector3 a = _target.transform.position;
            a.y = 0;
            transform.LookAt(a);
        }
        Vector3 tar = _target.transform.position;
        tar.y = 0;
        if (Vector3.Distance(transform.position, tar) <= attackingDistance)
        {
            if (!_isAttacking)
            {
                AttackState();
            }
            
        }
        else 
        {
            if (!_isWalking)
            {
                WalkState();
            }
            
        }
        
    }

    private Vector3 pos;
    private void WalkState()
    {
        animator.SetBool("walk",true);
        transform.DOKill();
        Vector3 tar = _target.transform.position;
        tar.y = 0;
        pos = tar;
        Debug.Log(_target + gameObject.name);
        transform.DOLookAt(tar, 0.1f);
        transform.DOMove(tar,0.5f*Vector3.Distance(transform.position,tar)).OnUpdate(() =>
        {
            if (!_target || pos != tar)
            {
                SetTarget();
                _isWalking = false;
                _isAttacking = false;
            }
            
        });
        _isWalking = true;
        _isAttacking = false;
    }
    private void AttackState()
    {
        transform.DOKill();
        animator.SetBool("walk",false);
        animator.SetTrigger("attack");
        _isWalking = false;
        _isAttacking = true;
    }

    public void AttackFinished()
    {
        _isAttacking = false;
        NPC n = _target.GetComponent<NPC>();
        if (_target && n)
        {
            n.Damage(damage);
        }
        
    }


    IEnumerator Timer() 
    {
        while (true)
        {
            SetTarget();
            yield return new WaitForSeconds(targetCheckCooldown);
        }
            
    }


  
}
