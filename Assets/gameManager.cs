using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;

    public Transform spawn1;
    public Transform spawn2;

    public float timeBetweenSpawns;
   
    public int enemiesSpawned;
    public int maxEnemiesToSpawn;
    public float randomSpawnPos;
    public float wave2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        randomSpawnPos = Random.Range(0, 2);
        StartCoroutine(spawnEnemies());
    }
    IEnumerator spawnEnemies()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        if (enemiesSpawned < maxEnemiesToSpawn)
        {
            if (randomSpawnPos == 0)
            {
                Instantiate(enemy1, spawn1.position, spawn1.rotation);
                enemiesSpawned += 1;
                
                
            }

            if (randomSpawnPos == 1)
            {
                Instantiate(enemy2, spawn2.position, spawn2.rotation);
                enemiesSpawned += 1;
              
            }
        }
        yield return new WaitForSeconds(3);
    }
}
