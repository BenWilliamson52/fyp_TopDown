using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next_level : MonoBehaviour
{

    /////////////// level 2 duplicating

    public int wavenum2 = 0;
    public int TimeWaves2;
    public bool spawnOn2 = false;
    public bool waveChange2 = false;

    public GameObject enemy1;
    public GameObject enemy2;

    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;

    public float timeBetweenSpawns2;
    public int enemiesSpawned2;
    public int maxEnemiesToSpawn2;
    public float randomSpawnPos2;

    public Text scoreText;
    int score = 16;

    void Start()
    {

        spawnOn2 = false;
        scoreText.text = score.ToString() + " Points";
    }

    public void Addpoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.instance.Addpoint();
            this.gameObject.SetActive(true);
            spawnOn2 = true;
        }
    }

    void FixedUpdate()
    {
        randomSpawnPos2 = Random.Range(0, 5);

        if (spawnOn2 == true && wavenum2 < 3)
        {
            StartCoroutine(spawnEnemies2());
        }

        if (score >= 31) // this is LEVEL 2
        {
            //door2.gameObject.SetActive(false);
            //level3.gameObject.SetActive(true);
        }

    }

    IEnumerator spawnEnemies2()
    {
        spawnOn2 = false;
        if (enemiesSpawned2 == maxEnemiesToSpawn2)
        {
            waveChange2 = true;
        }
        if (waveChange2 == true)
        {
            yield return new WaitForSeconds(TimeWaves2);
            wavenum2++;
            maxEnemiesToSpawn2 += 2;
            enemiesSpawned2 = 0;
            waveChange2 = false;
        }


        yield return new WaitForSeconds(timeBetweenSpawns2);
        if (enemiesSpawned2 < maxEnemiesToSpawn2)
        {
            if (randomSpawnPos2 == 0)
            {
                Instantiate(enemy1, spawn5.position, spawn5.rotation);
                enemiesSpawned2 += 1;

            }
            if (randomSpawnPos2 == 1)
            {
                Instantiate(enemy2, spawn6.position, spawn6.rotation);
                enemiesSpawned2 += 1;

            }
            if (randomSpawnPos2 == 3)
            {
                Instantiate(enemy2, spawn7.position, spawn7.rotation);
                enemiesSpawned2 += 1;

            }
            if (randomSpawnPos2 == 4)
            {
                Instantiate(enemy1, spawn8.position, spawn8.rotation);
                enemiesSpawned2 += 1;

            }
        }
        spawnOn2 = true;
    }
}
