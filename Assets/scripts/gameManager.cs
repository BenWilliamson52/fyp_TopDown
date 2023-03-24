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

    [Header("Changing points needed")]
    public int area1points = 0;
    public int area2points = 0;
    public int area3points = 0;


    [Header("Waves + Spawning")]
    public int wavenum = 0;
    public int TimeWaves;
    public bool spawnOn = false;
    public bool spawnOn2 = false;
    public bool spawnOn3 = false;
    public bool waveChange = false; // next set of enemies
    public bool triggerLink = false; // starts  spawning for area 2
    public bool triggerLink3 = false; // starts  spawning for area 3

    //for fade out

    [Header("Fade Out Objects")]
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;

    [Header("Fades Doors + settings")]
    public float fadeDelay = 5f;
    public float alphaValue = 0;
    public float fadeDuration = 1.0f; // how long the fade lasts
    private bool isFadingOut = false; // fading out is in progress
    private bool isFadingOut2 = false; 


   


    [Header("HUD Text")]
    public GameObject levelText;
    public Text scoreText;
    int score = 0;

    [Header("Enemies")]
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    [Header("Level Items")]
    public GameObject door1;
    public GameObject door2;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public float timeBetweenSpawns;

    [Header("Misc Spawns")]
    public bool destroyGameObject = false;
    public int enemiesSpawned;
    public int maxEnemiesToSpawn;
    public float randomSpawnPos;

    [Header("Area 1 Spawns")]
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    [Header("Area 2 Spawns")]
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    [Header("Area 3 Spawns")]
    public Transform spawn9;
    public Transform spawn10;
    public Transform spawn11;
    public Transform spawn12;

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

        if (score >= area1points) // this is LEVEL 1
        {
            //door1.gameObject.SetActive(false); // door opens next area
            if (!isFadingOut)
            {
                StartCoroutine(fade());
            }

            level2.gameObject.SetActive(true);
        }

        if (score >= area2points) // this is LEVEL 2
        {
            //door1.gameObject.SetActive(false); // door opens next area
            if (!isFadingOut2)
            {
                StartCoroutine(fade2());
            }

            level3.gameObject.SetActive(true); // sets up 3rd "level"
        }

        if (score >= area3points) // this is LEVEL 3
        {

            level4.gameObject.SetActive(true); // sets up 3rd "level"
        }

        if (triggerLink == true && wavenum >= 3 && wavenum < 5 && spawnOn2 == true)
        {
            StartCoroutine(spawnEnemiesArea2());
        }

        if (triggerLink3 == true && wavenum >= 1 && wavenum < 7 && spawnOn3 == true)
        {
            StartCoroutine(spawnEnemiesArea3());
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

    IEnumerator fade2()
    {
        isFadingOut2 = true;

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
        door2.gameObject.SetActive(false); // door opens next area
    }

    IEnumerator spawnEnemiesArea3()
    {
        spawnOn3 = false;
        if (enemiesSpawned == maxEnemiesToSpawn)
        {
            waveChange = true;
        }
        if (waveChange == true)
        {
            yield return new WaitForSeconds(TimeWaves);
            wavenum++;
            maxEnemiesToSpawn += 4;
            enemiesSpawned = 0;
            waveChange = false;
        }


        yield return new WaitForSeconds(timeBetweenSpawns);
        if (enemiesSpawned < maxEnemiesToSpawn)
        {
            if (randomSpawnPos == 0)
            {
                Instantiate(enemy3, spawn9.position, spawn9.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 1)
            {
                Instantiate(enemy3, spawn10.position, spawn10.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 3)
            {
                Instantiate(enemy3, spawn11.position, spawn11.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 4)
            {
                Instantiate(enemy3, spawn12.position, spawn12.rotation);
                enemiesSpawned += 1;

            }
        }
        spawnOn3 = true;

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
