using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimEvent : MonoBehaviour
{
    [SerializeField] private NPCFire npcFire;
    public void Fire()
    {
        npcFire.Fire();
    }
}
