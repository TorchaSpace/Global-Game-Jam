using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MağaraSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public int mağaraCount = 0;

    public Transform player;

    public float timer = 5f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 5;
            SpawnRandomSpot();
        }
    }


    public void SpawnRandomSpot()
    {
        if (mağaraCount <= 50)
        {
            int ranX = Random.Range(-50, 50);
            int ranZ = Random.Range(-50, 50);
            Vector3 randomPosition = new Vector3(player.position.x + ranX, 0f, player.position.z + ranZ);
            Instantiate(spawnPrefab, randomPosition, Quaternion.identity);
            mağaraCount++;
        }
    }
}
