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

    //for fade out
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;

    public float fadeDuration = 1.0f; // how long the fade lasts
    private bool isFadingOut = false; // fading out is in progress

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
            //door1.gameObject.SetActive(false); // door opens next area
            if (!isFadingOut)
            {
                StartCoroutine(fade());
            }

            level2.gameObject.SetActive(true);
        }

        if(triggerLink == true && wavenum >= 3 && wavenum < 5 && spawnOn2 == true)
        {
            StartCoroutine(spawnEnemiesArea2());
        }
   
    }
        
    IEnumerator fade()
    {
        isFadingOut = true;

        // get the initial color of the sprite

        Color initialColor = spriteRenderer.color;

        // calculate the rate at which the sprite should fade out per second
        float fadePerSecond = 1.0f / fadeDuration;

        // keep fading the sprite until it's completely transparent
        while (spriteRenderer.color.a > 0.0f)
        {
            // calculate the new color of the sprite based on the fade rate and time elapsed
            float fadeAmount = spriteRenderer.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);
            float fadeAmount2 = spriteRenderer2.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor2 = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);
            float fadeAmount3 = spriteRenderer3.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor3 = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);



            // update the sprite color
            spriteRenderer.color = newColor;
            spriteRenderer2.color = newColor;
            spriteRenderer3.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        spriteRenderer2.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        spriteRenderer3.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        isFadingOut = false;
        door1.gameObject.SetActive(false); // door opens next area
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
