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

    [Header("Changing points as needed")]
    public int area1points = 0;
    public int area2points = 0;
    public int area3points = 0;
    public int area4points = 0;
    public int area5points = 0;
    public int area6points = 0;
    public int area7points = 0;


    [Header("Waves + Spawning ( best to not touch )")]
    public int wavenum = 0;
    public int TimeWaves;
    public bool spawnOn = false;
    public bool spawnOn2 = false;
    public bool spawnOn3 = false;
    public bool spawnOn4 = false;
    public bool spawnOn5 = false;
    public bool spawnOn6 = false;
    public bool spawnOn7 = false;
    //
    public bool waveChange = false; // next set of enemies
    public bool triggerLink = false; // starts  spawning for area 2
    public bool triggerLink3 = false; // starts  spawning for area 3
    public bool triggerLink4 = false; // starts spawning for area 4
    public bool triggerLink5 = false; // starts spawning for area 5
    public bool triggerLink6 = false; // starts spawning for area 6
    public bool triggerLink7 = false; // starts spawning for area 7

    //for fade out

    [Header("Fade Out Objects")]
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public SpriteRenderer spriteRenderer4;
    public SpriteRenderer spriteRenderer5;
    public SpriteRenderer spriteRenderer6;

    [Header("Fades Doors + settings")]
    public float fadeDelay = 5f;
    public float alphaValue = 0;
    public float fadeDuration = 1.0f; // how long the fade lasts
    private bool isFadingOut = false; // fading out is in progress
    private bool isFadingOut2 = false;
    private bool isFadingOut3 = false;
    private bool isFadingOut4 = false;
    private bool isFadingOut5 = false;
    private bool isFadingOut6 = false;


   


    [Header("HUD Text")]
    public GameObject levelText;
    public Text scoreText;
    int score = 0;

    [Header("Enemies")]
    public GameObject enemy1; // green swamp orc
    public GameObject enemy2; // red snake 
    public GameObject enemy3; // tauros
    public GameObject enemy4; // skelly

    [Header("Level Items")]
    [Header("doors")]
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject door6;
    public GameObject door7;
    public GameObject bridge;
    public GameObject bossBlocker;
    [Header("Level triggers")]
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
   
    public float timeBetweenSpawns;

    [Header("Door open Text")]
    public GameObject Door1Open;
    //public GameObject Door2Open;
    //public GameObject Door3Open;
    public int appearTime;
    public int transitionTime = 1;

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
    [Header("Area 4 Spawns")]
    public Transform spawn13;
    public Transform spawn14;
    public Transform spawn15;
    [Header("Area 5 Spawns")]
    public Transform spawn16;
    public Transform spawn17;
    public Transform spawn18;
    [Header("Area 6 Spawns")]
    public Transform spawn19;
    public Transform spawn20;
    [Header("Area 7 Spawns")]
    public Transform spawnBOSS; // not in use
    public GameObject finalHealthBar;
    [Header("endscreen")]
    public GameObject killedTheBoss;



    private void Awake()
    {
        instance= this;
    }


    // Start is called before the first frame update
    void Start()
    {
        spawnOn = true;
        scoreText.text = score.ToString() + " Points";
        Door1Open.gameObject.SetActive(false);
        transitionTime = 1;

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

   

        if (spawnOn == true && wavenum < 3) // starting spawns
        {
            StartCoroutine(spawnEnemies());
        }

        if (score >= area1points) // this is LEVEL 1
        {
            if (!isFadingOut)
            {
                StartCoroutine(fade()); // fades away door 1
            }

            level2.gameObject.SetActive(true); // sets up level 2
            if (transitionTime == 1)
            {
                StartCoroutine(transition1());
                transitionTime = transitionTime + 1; // stops the pop-up from spamming
            }
            
        }

        IEnumerator transition1()
        {
            Door1Open.gameObject.SetActive(true); // gameobject that appears on screen
            yield return new WaitForSeconds(appearTime); // waiting for (appearTime) seconds
            Door1Open.gameObject.SetActive(false); // on screen popup leaves
            
        }

        if (score >= area2points) // this is LEVEL 2
        {
            if (!isFadingOut2)
            {
                StartCoroutine(fade2());
            }

            level3.gameObject.SetActive(true); // sets up 3rd "level"
            if (transitionTime == 2)
            {
                StartCoroutine(transition1());
                transitionTime = transitionTime + 1; // stops the pop-up from spamming
            }
        }

        if (score >= area3points) // this is LEVEL 3
        {
            if (!isFadingOut3)
            {
                StartCoroutine(fade3());
            }
            level4.gameObject.SetActive(true); // sets up 4th "level"
            if (transitionTime == 3)
            {
                StartCoroutine(transition1());
                transitionTime = transitionTime + 1; // stops the pop-up from spamming
            }
        }

        if (score >= area4points) // this is LEVEL 4
        {
            if (!isFadingOut4)
            {
                StartCoroutine(fade4());
            }
            level5.gameObject.SetActive(true); // sets up 5th "level"
            if (transitionTime == 4)
            {
                StartCoroutine(transition1());
                transitionTime = transitionTime + 1; // stops the pop-up from spamming
            }
        }

        if (score >= area5points) // this is LEVEL 5
        {
            if (!isFadingOut5)
            {
                StartCoroutine(fade5());
            }
            level6.gameObject.SetActive(true); // sets up 6th "level"
            if (transitionTime == 5)
            {
                StartCoroutine(transition1());
                transitionTime = transitionTime + 1; // stops the pop-up from spamming
            }
        }

        if (score >= area6points) // this is LEVEL 6
        {
            if (!isFadingOut6)
            {
                StartCoroutine(fade6());
            }
            level7.gameObject.SetActive(true); // sets up 7th "level"
            if (transitionTime == 6)
            {
                StartCoroutine(transition1());
                transitionTime = transitionTime + 1; // stops the pop-up from spamming
            }
        }




        ////////////////
        if (triggerLink == true && wavenum >= 3 && wavenum < 6 && spawnOn2 == true)
        {
            StartCoroutine(spawnEnemiesArea2());
        }

        if (triggerLink3 == true && wavenum >= 6 && wavenum < 9 && spawnOn3 == true)
        {
            StartCoroutine(spawnEnemiesArea3());
        }

        if (triggerLink4 == true && wavenum >= 9 && wavenum < 12 && spawnOn4 == true)
        {
            StartCoroutine(spawnEnemiesArea4());
        }

        if (triggerLink5 == true && wavenum >= 12 && wavenum < 15 && spawnOn5 == true)
        {
            StartCoroutine(spawnEnemiesArea5());
        }

        if (triggerLink6 == true && wavenum >= 15 && wavenum < 18 && spawnOn6 == true)
        {
            StartCoroutine(spawnEnemiesArea6());
        }

        if (triggerLink7 == true )
        {
            StartCoroutine(finalBoss());
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

            // update the sprite color
            spriteRenderer.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        isFadingOut = false;
        door1.gameObject.SetActive(false); // door opens next area
    }

    IEnumerator fade2()
    {
        isFadingOut2 = true;

        // get the initial color of the sprite

        Color initialColor = spriteRenderer2.color;

        // calculate the rate at which the sprite should fade out per second
        float fadePerSecond = 1.0f / fadeDuration;

        // keep fading the sprite until it's completely transparent
        while (spriteRenderer2.color.a > 0.0f)
        {
            // calculate the new color of the sprite based on the fade rate and time elapsed
            float fadeAmount = spriteRenderer2.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);

            // update the sprite color
            spriteRenderer2.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer2.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        isFadingOut2 = false;
        door2.gameObject.SetActive(false); // door opens next area
    }

    IEnumerator fade3()
    {
        isFadingOut3 = true;

        // get the initial color of the sprite

        Color initialColor = spriteRenderer3.color;

        // calculate the rate at which the sprite should fade out per second
        float fadePerSecond = 1.0f / fadeDuration;

        // keep fading the sprite until it's completely transparent
        while (spriteRenderer3.color.a > 0.0f)
        {
            // calculate the new color of the sprite based on the fade rate and time elapsed
            float fadeAmount = spriteRenderer3.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);

            // update the sprite color
            spriteRenderer3.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer3.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);

        isFadingOut3 = false;
        door3.gameObject.SetActive(false); // door opens next area
        bridge.gameObject.SetActive(true); // bridge to next area (4)
    }

    IEnumerator fade4()
    {
        isFadingOut4 = true;

        // get the initial color of the sprite

        Color initialColor = spriteRenderer4.color;

        // calculate the rate at which the sprite should fade out per second
        float fadePerSecond = 1.0f / fadeDuration;

        // keep fading the sprite until it's completely transparent
        while (spriteRenderer4.color.a > 0.0f)
        {
            // calculate the new color of the sprite based on the fade rate and time elapsed
            float fadeAmount = spriteRenderer4.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);
   
            // update the sprite color
            spriteRenderer4.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer4.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);

        isFadingOut4 = false;
        door4.gameObject.SetActive(false); // door opens next area
    }

    IEnumerator fade5()
    {
        isFadingOut5 = true;

        // get the initial color of the sprite

        Color initialColor = spriteRenderer5.color;

        // calculate the rate at which the sprite should fade out per second
        float fadePerSecond = 1.0f / fadeDuration;

        // keep fading the sprite until it's completely transparent
        while (spriteRenderer5.color.a > 0.0f)
        {
            // calculate the new color of the sprite based on the fade rate and time elapsed
            float fadeAmount = spriteRenderer5.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);

            // update the sprite color
            spriteRenderer5.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer5.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);

        isFadingOut5 = false;
        door5.gameObject.SetActive(false); // door opens next area
    }

    IEnumerator fade6()
    {
        isFadingOut6 = true;

        // get the initial color of the sprite

        Color initialColor = spriteRenderer6.color;

        // calculate the rate at which the sprite should fade out per second
        float fadePerSecond = 1.0f / fadeDuration;

        // keep fading the sprite until it's completely transparent
        while (spriteRenderer6.color.a > 0.0f)
        {
            // calculate the new color of the sprite based on the fade rate and time elapsed
            float fadeAmount = spriteRenderer6.color.a - (fadePerSecond * Time.deltaTime);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, fadeAmount);
  
            // update the sprite color
            spriteRenderer6.color = newColor;

            // wait for the next frame to continue the loop
            yield return null;
        }

        // set the sprite color to completely transparent
        spriteRenderer6.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        isFadingOut5 = false;
        door6.gameObject.SetActive(false); // door opens next area
    }

    IEnumerator finalBoss()
    {
        door7.gameObject.SetActive(true);
        bossBlocker.gameObject.SetActive(false);
        finalHealthBar.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
    }

    IEnumerator spawnEnemiesArea6()
    {
        spawnOn5 = false;
        if (enemiesSpawned == maxEnemiesToSpawn)
        {
            waveChange = true;
        }
        if (waveChange == true)
        {
            yield return new WaitForSeconds(TimeWaves);
            wavenum++;
            //maxEnemiesToSpawn += 1;
            enemiesSpawned = 0;
            waveChange = false;
        }


        yield return new WaitForSeconds(timeBetweenSpawns);
        if (enemiesSpawned < maxEnemiesToSpawn)
        {
            if (randomSpawnPos == 0)
            {
                Instantiate(enemy1, spawn19.position, spawn13.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 1)
            {
                Instantiate(enemy1, spawn19.position, spawn14.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 3)
            {
                Instantiate(enemy3, spawn20.position, spawn15.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 4)
            {
                Instantiate(enemy4, spawn20.position, spawn15.rotation);
                enemiesSpawned += 1;

            }
        }
        spawnOn6 = true;

    }

    IEnumerator spawnEnemiesArea5()
    {
        spawnOn5 = false;
        if (enemiesSpawned == maxEnemiesToSpawn)
        {
            waveChange = true;
        }
        if (waveChange == true)
        {
            yield return new WaitForSeconds(TimeWaves);
            wavenum++;
            //maxEnemiesToSpawn += 1;
            enemiesSpawned = 0;
            waveChange = false;
        }


        yield return new WaitForSeconds(timeBetweenSpawns);
        if (enemiesSpawned < maxEnemiesToSpawn)
        {
            if (randomSpawnPos == 0)
            {
                Instantiate(enemy4, spawn16.position, spawn13.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 1)
            {
                Instantiate(enemy4, spawn16.position, spawn14.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 3)
            {
                Instantiate(enemy1, spawn17.position, spawn15.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 4)
            {
                Instantiate(enemy4, spawn18.position, spawn15.rotation);
                enemiesSpawned += 1;

            }
        }
        spawnOn5 = true;

    }

    IEnumerator spawnEnemiesArea4()
    {
        spawnOn4 = false;
        if (enemiesSpawned == maxEnemiesToSpawn)
        {
            waveChange = true;
        }
        if (waveChange == true)
        {
            yield return new WaitForSeconds(TimeWaves);
            wavenum++;
            //maxEnemiesToSpawn += 1;
            enemiesSpawned = 0;
            waveChange = false;
        }


        yield return new WaitForSeconds(timeBetweenSpawns);
        if (enemiesSpawned < maxEnemiesToSpawn)
        {
            if (randomSpawnPos == 0)
            {
                Instantiate(enemy4, spawn13.position, spawn13.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 1)
            {
                Instantiate(enemy4, spawn14.position, spawn14.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 3 )
            {
                Instantiate(enemy1, spawn15.position, spawn15.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 4)
            {
                Instantiate(enemy4, spawn15.position, spawn15.rotation);
                enemiesSpawned += 1;

            }
        }
        spawnOn4 = true;

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
            //maxEnemiesToSpawn += 1;
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
            //maxEnemiesToSpawn += 1;
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
                Instantiate(enemy1, spawn6.position, spawn6.rotation);
                enemiesSpawned += 1;

            }
            if (randomSpawnPos == 3)
            {
                Instantiate(enemy1, spawn7.position, spawn7.rotation);
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
            //maxEnemiesToSpawn += 1;
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
