using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NPCFire : MonoBehaviour
{
    [SerializeField] private float radius = 5;
    RaycastHit hit;
    [SerializeField] private List<Transform> currentEnemies;
    [SerializeField] private float timeBetweenFire;

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Projectile projectilePrefab;

    [SerializeField] private Animator anim;
    
    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            if (currentEnemies.Count > 0)
            {
                for (int i = currentEnemies.Count-1; i >= 0; i--)
                {
                    if (currentEnemies[i] == null)
                    {
                        currentEnemies.RemoveAt(i);
                    }
                }

                if (currentEnemies.Count > 0)
                {
                    FireAnimation();
                }
                
                yield return new WaitForSeconds(timeBetweenFire);
            }

            yield return null;
        }
    }

    private void FireAnimation()
    {
        Vector3 a = currentEnemies[0].position;
        a.y = transform.position.y;
        transform.DOLookAt(a, 0.1f);
        anim.SetTrigger("Fire");
    }

    public void Fire()
    {
        for (int i = currentEnemies.Count-1; i >=0; i--)
        {
            if (!currentEnemies[i])
            {
                currentEnemies.RemoveAt(i);
            }
        }
        if (currentEnemies.Count < 1) return;
        
        Projectile p = Instantiate(projectilePrefab, shootingPoint.position + projectilePrefab.transform.position,projectilePrefab.transform.rotation);
        Vector3 a = currentEnemies[0].position;
        a.y = transform.position.y;
        p.Fire(a);

    }
    
    


    private void FixedUpdate()
    {
        if (Physics.SphereCast(transform.position,radius,transform.forward,out hit,radius,layerMask:LayerMask.GetMask("Enemy")))
        {
            currentEnemies.Add(hit.transform);
        }
    }
    
    
    
    
    
    
}
