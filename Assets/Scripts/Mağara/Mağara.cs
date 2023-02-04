using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mağara : MonoBehaviour
{
    public float scanRadius = 20f;
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
