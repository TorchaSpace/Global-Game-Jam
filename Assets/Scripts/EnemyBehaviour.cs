using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private List<GameObject> Targets = new List<GameObject>();
    [SerializeField] private GameObject _target;
    [SerializeField] private float targetCheckCooldown;
    [SerializeField] private float minTargetingDistance;
    private float attackingDistance = 2;
    private GameObject _currentTarget;
    private Vector3 _direction;
    private float _movementSpeed = 5;

    private GameObject _tree;
    public void Damage(float damageAmount)
    {

    }

    private void Start()
    {
        _tree = GameObject.FindGameObjectWithTag("Tree");
        Targets.Add(GameObject.FindGameObjectWithTag("Player"));
        Targets.Add(_tree);
        StartCoroutine(Timer());
    }
    private void Update()
    {
        StateChecker();
    }

    public void GetTarget(GameObject target)
    {
        Targets.Add(target);
    }

    private void SetTarget()
    {
        float distance = Mathf.Infinity;
        float newDistance;
        foreach (GameObject target in Targets)
        {
            newDistance = Vector3.Distance(target.transform.position, transform.position);
            {
                if (newDistance < distance)
                {
                    distance = newDistance;
                    _currentTarget = target;
                }
            }
        }
            _target = _currentTarget;
    }

    private void StateChecker()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) <= attackingDistance)
        {
            AttackState();
        }
        else 
        {
            WalkState();
        }
    }
    private void WalkState()
    {
        _direction = _target.transform.position - transform.position;
        _direction.Normalize();
        transform.Translate(_direction * _movementSpeed * Time.deltaTime);
    }
    private void AttackState() 
    {
    
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
