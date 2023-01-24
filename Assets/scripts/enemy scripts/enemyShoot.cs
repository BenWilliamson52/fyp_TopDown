using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public float enemyBulletForce = 5f;
    public Transform enemyFirePoint;
    public GameObject enemyBulletPrefab;

 
    public GameObject player;
    public Rigidbody2D rb;

    public float timer;


    //public playerMovement player;

    public float speed;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        EnemyMoveShoot();

        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            bang();
        }
  

    }

    void bang()
    {
         GameObject EnemyBullet = Instantiate(enemyBulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation);
         Rigidbody2D rb = EnemyBullet.GetComponent<Rigidbody2D>();
         rb.AddForce(enemyFirePoint.up * enemyBulletForce, ForceMode2D.Impulse);
    }



    public void EnemyMoveShoot()
    {
        if (transform.position.x > (player.transform.position.x) + 2 )
        {
            transform.position -= new Vector3(speed, 0) * Time.deltaTime;
        }

        if (transform.position.x < (player.transform.position.x) + 2 )
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
        }

        if (transform.position.y < (player.transform.position.y) + 2)
        {
            transform.position += new Vector3(0, speed) * Time.deltaTime;
        }

        if (transform.position.y > (player.transform.position.y) + 2)
        {
            transform.position -= new Vector3(0, speed) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            gameManager.instance.Addpoint();

        }
    }
}

