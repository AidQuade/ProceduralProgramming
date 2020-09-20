using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBodySpawner : MonoBehaviour
{
    public GameObject spawnMe;
    public GameObject[] itemsToSpawn;

    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 positionRandomization;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }
// Spawn items in a grid and call the randomPick function with a slightly randomized position
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPos = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset);
                RandomPick(RandomizePostion(spawnPos), Quaternion.identity);
            }
        }
    }

    Vector3 RandomizePostion(Vector3 position)
    {
        Vector3 randomizedPos = new Vector3(Random.Range(-positionRandomization.x, positionRandomization.x),Random.Range(-positionRandomization.y, positionRandomization.y),Random.Range(-positionRandomization.z, positionRandomization.z));
        return randomizedPos;
    }
   //Allow multiple game objects to randomly be chosen from and spawned
    void RandomPick(Vector3 positionSpawn, Quaternion rotationSpawn)
    {
        int randomIndex = Random.Range(0, itemsToSpawn.Length);
        GameObject clone = Instantiate(itemsToSpawn[randomIndex], positionSpawn, rotationSpawn);
    }
}
