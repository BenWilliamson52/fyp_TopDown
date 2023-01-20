using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int wavenum = 0;
    public int TimeWaves;
    public bool spawnOn = false;
    public bool waveChange = false;

    public Text scoreText;
    int score = 0;

    public GameObject levelText;
    public GameObject enemy1;
    public GameObject enemy2;

    public Transform spawn1;
    public Transform spawn2;

    public float timeBetweenSpawns;
   
    public int enemiesSpawned;
    public int maxEnemiesToSpawn;
    public float randomSpawnPos;

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
        randomSpawnPos = Random.Range(0, 2);

        if (spawnOn == true && wavenum < 3)
        {
            StartCoroutine(spawnEnemies());
        }

        if (score >= 16)
        {
            levelText.gameObject.SetActive(true);
        }
   
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
        }
        spawnOn= true;
    }



}
