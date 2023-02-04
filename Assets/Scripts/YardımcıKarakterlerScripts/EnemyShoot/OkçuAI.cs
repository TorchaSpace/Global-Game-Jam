using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkçuAI : MonoBehaviour
{
    public float scanRadius = 3f;
    public LayerMask filterMask;
    private Collider2D checkCollider;

    void Update()
    {
        checkCollider = Physics2D.OverlapCircle(transform.position, scanRadius, filterMask);

        if (checkCollider != null && checkCollider.transform != transform)
        {
            Destroy(checkCollider.gameObject);
        }
    }
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
