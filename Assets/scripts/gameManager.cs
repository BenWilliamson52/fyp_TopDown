using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// enemyshoot needs to look at me and shoot
// bullets need to dissapear when they miss, not just when they collide
// research tilemap

//when wave 1 is completed, popup door opened

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int wavenum = 0;
    public int TimeWaves;
    public bool spawnOn = false;
    public bool spawnOn2 = false;
    public bool waveChange = false;
    public bool triggerLink = false;

    public Text scoreText;
    int score = 0;

    public GameObject levelText;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject door1;
    public GameObject level2;
    public GameObject fog1;

    public float timeBetweenSpawns;
    public float fadeDelay = 5f;
    public float alphaValue = 0;
    public bool destroyGameObject = false;
   
    public int enemiesSpawned;
    public int maxEnemiesToSpawn;
    public float randomSpawnPos;

    [Header("Area1")]
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    [Header("Area2")]
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;

    private void Awake()
    {
        instance= this;
    }



    // Start is called before the first frame update
    void Start()
    {
        spawnOn = true;
        scoreText.text = score.ToString() + " Points";

    }

    public void Addpoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        randomSpawnPos = Random.Range(0, 5);

        if (spawnOn == true && wavenum < 3)
        {
            StartCoroutine(spawnEnemies());
        }

        if (score >= 1) // this is LEVEL 1
        {
            door1.gameObject.SetActive(false);
            level2.gameObject.SetActive(true);
        }

        if(triggerLink == true && wavenum >= 3 && wavenum < 5 && spawnOn2 == true)
        {
            StartCoroutine(spawnEnemiesArea2());
        }
   
    }

    IEnumerator spawnEnemiesArea2()
    {
        spawnOn2 = false;
        if (enemiesSpawned == maxEnemiesToSpawn)
        {
            waveChange = true;
        }
        if (waveChange == true)
        {
            yield return new WaitForSeconds(TimeWaves);
            wavenum++;
            maxEnemiesToSpawn += 2;
            enemiesSpawned = 0;
            waveChange = false;
        }


        yield return new WaitForSeconds(timeBetweenSpawns);
        if (enemiesSpawned < maxEnemiesToSpawn)
        {
            if (randomSpawnPos == 0)
            {
                Instantiate(enemy1, spawn5.position, spawn5.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 1)
            {
                Instantiate(enemy2, spawn6.position, spawn6.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 3)
            {
                Instantiate(enemy2, spawn7.position, spawn7.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 4)
            {
                Instantiate(enemy1, spawn8.position, spawn8.rotation);
                enemiesSpawned += 1;

            }
        }
        spawnOn2 = true;
    
}

    IEnumerator spawnEnemies()
    {
        spawnOn= false;
        if (enemiesSpawned == maxEnemiesToSpawn)
        {
            waveChange = true;
        }
        if (waveChange == true)
        {
            yield return new WaitForSeconds(TimeWaves);
            wavenum++;
            maxEnemiesToSpawn += 2;
            enemiesSpawned = 0;
            waveChange = false;
        }


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
            if (randomSpawnPos == 3)
            {
                Instantiate(enemy2, spawn3.position, spawn3.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 4)
            {
                Instantiate(enemy1, spawn4.position, spawn4.rotation);
                enemiesSpawned += 1;

            }
        }
        spawnOn= true;
    }



}
