using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkçuSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform[] spawnPoints;
    public int okcuCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnRandomSpot();
        }
    }

    public void SpawnRandomSpot()
    {
        if(okcuCount <= 10)
        {
            Instantiate(spawnPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            okcuCount++;
        }
    }
}
