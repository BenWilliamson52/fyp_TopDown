using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public GameObject killedTheBoss;

    public GameObject player;
    public Rigidbody2D rb;

    public int bossHealth;
    public Slider bossHealthBar;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        killedTheBoss.gameObject.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
        //lookingPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //if (bossHealth <= 0 ) 
        //{
        //    killedTheBoss.gameObject.SetActive(true);
        //}
        bossHealthBar.value = bossHealth;

        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMoveMelee();
    }

    public void EnemyMoveMelee()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.position -= new Vector3(speed, 0) * Time.deltaTime;
        }

        if (transform.position.x < player.transform.position.x)
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
        }

        if (transform.position.y < player.transform.position.y)
        {
            transform.position += new Vector3(0, speed) * Time.deltaTime;
        }

        if (transform.position.y > player.transform.position.y)
        {
            transform.position -= new Vector3(0, speed) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            bossHealth --;
        }

        if(bossHealth <= 0)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            killedTheBoss.gameObject.SetActive(true);
        }
    }
}

