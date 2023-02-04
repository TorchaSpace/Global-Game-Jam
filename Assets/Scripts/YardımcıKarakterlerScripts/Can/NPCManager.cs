using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    
    public List<NPC> archers = new List<NPC>();
    private int[] randomizers = new int[] { -1, 1 };
    [SerializeField] private float maxSpawnRadius = 10;
    [SerializeField] private float minSpawnRadius = 70;
    [SerializeField] private float maxMoveRadius = 3;
    [SerializeField] private float minMoveRadius = 7;

    [SerializeField] private NPC npcPrefab;
    [SerializeField] private float timeBetweenInstantiate = 2;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(CreateNPC());
    }


    private IEnumerator CreateNPC()
    {
        while (true)
        {
            Vector3 a = new Vector3(Random.Range(0f, 1f) * randomizers[Random.Range(0, randomizers.Length)],
                                1.8f, Random.Range(0f, 1f) * randomizers[Random.Range(0, randomizers.Length)])
                            .normalized *
                        Random.Range(minSpawnRadius, maxSpawnRadius);
            a.y = 1.8f;
            Instantiate(npcPrefab,a , Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenInstantiate);
        }
    }
    

    public void AddArcher(NPC n)
    {
        if (!archers.Contains(n))
        {
            archers.Add(n);
        }
    }
    
    
    public void RemoveArcher(NPC n)
    {
        if (archers.Contains(n))
        {
            archers.Remove(n);
        }
    }


    public Vector3 GetRandomPos()
    {
        Vector3 randomPos = new Vector3(Random.Range(0f, 1f) * randomizers[Random.Range(0, randomizers.Length)], 
            0, Random.Range(0f, 1f) * randomizers[Random.Range(0, randomizers.Length)]).normalized * Random.Range(minMoveRadius, maxMoveRadius);

        return randomPos;
    }
    
    
    
    
}
