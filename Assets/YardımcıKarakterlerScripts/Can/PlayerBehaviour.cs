using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    void Update()
    {
        //if(Bir şey olacak)
        //{
        TakeDamage(10);
        //}

        //if(Bir şey olacak)
        //{
        GetHeal(5);
        //}
    }

    private  void TakeDamage(int damage)
    {
        GameManager.gameManager.playerHealth.Damage(damage);
    }

    private void GetHeal(int regen)
    {
        GameManager.gameManager.playerHealth.Regen(regen);
    }
}
