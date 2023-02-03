using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponHolder : WeaponHolder
{
     public Projectile projectilePrefab;
     public Transform handPos;

     public override void Fire(Vector3 direction)
     {
          Projectile p = Instantiate(projectilePrefab, handPos.position, handPos.rotation);
          p.Fire(direction);
     }
}
