using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreeController : MonoBehaviour
{
        [SerializeField] int EnemyCount;
        public Action OnLevelLost;
        private void OnTriggerEnter(Collider collider)
        {
            EnemyCount++;
           
            if (EnemyCount>=30)
            {
                OnLevelLost?.Invoke();
            }
         }
}
