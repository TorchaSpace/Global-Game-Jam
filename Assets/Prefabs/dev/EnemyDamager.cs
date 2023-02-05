using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterHealthSystem>())
        {
            other.GetComponent<CharacterHealthSystem>().Damage(5);
        }
    }
}
