using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Enemy enemy;

    public Slider healthBar;
    public Text enemyName;

    public GameObject enemyPrefab;

    

    private void Start()
    {
        enemy.OnEnemyDamaged += OnHealthChanged;       
    }

    void OnHealthChanged(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    public void TakeDamageFromPlayer()
    {
        //hasar ver beya
    }

    public void TakeDamageFromHelper()
    {
        enemy.Damage(10);
    }

    private void Update()
    {
        healthBar.value = enemy.GetHealth();
        enemyName.text = enemy.GetName();

        KillEnemy();
    }

    public void KillEnemy()
    {
        if(enemy.health <= 0)
        {
            Destroy(enemyPrefab);
        }
    }

}
