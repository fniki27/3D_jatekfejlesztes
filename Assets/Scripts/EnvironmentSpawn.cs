using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawn : MonoBehaviour
{
    public GameObject[] environmentPrefab;
    public float spawnPoint;
    private float length = 96;
    public int numberOfEnv;

    public Transform player;
    private List<GameObject> activeEnv = new List<GameObject>();


    private void Start()
    {
        for(int i = 0; i < numberOfEnv; i++)
        {
            SpawnEnvironment(Random.Range(0, environmentPrefab.Length));
        }
    }

    private void Update()
    {
        if (player.position.z -100 > spawnPoint - (numberOfEnv * length))
        {
            SpawnEnvironment(Random.Range(0, environmentPrefab.Length));
            DestroyEnv();
        }
    }

    public void SpawnEnvironment(int spawnIndex)
    {
        GameObject spawnedObject = Instantiate(environmentPrefab[spawnIndex], new Vector3(4f, 0, 1f * spawnPoint), transform.rotation);
        activeEnv.Add(spawnedObject);
        spawnPoint += length;
    }

    
    private void DestroyEnv()
    {
        Destroy(activeEnv[0]);
        activeEnv.RemoveAt(0);
    }
}

