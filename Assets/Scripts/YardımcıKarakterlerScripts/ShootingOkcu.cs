using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOkcu : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float timer = 3;

    public Transform target;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 3;
            Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

   
}
