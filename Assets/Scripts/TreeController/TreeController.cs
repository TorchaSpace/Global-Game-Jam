using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreeController : MonoBehaviour
{
        [SerializeField] private int enemyCount;
        private int _currentEnemyCount = 0;
        public Action OnLevelLost;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<EnemyBehaviour>())
            {
                _currentEnemyCount++;
                Destroy(other.gameObject);
                if (_currentEnemyCount>=enemyCount)
                {
                    OnLevelLost?.Invoke();
                }
            }
            
        }
}
