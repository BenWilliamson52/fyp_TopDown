using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    //public playerMovement player;

    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMoveShoot();
    }

    public void EnemyMoveShoot()
    {
        if (transform.position.x > (player.transform.position.x) * 3 )
        {
            transform.position -= new Vector3(speed, 0) * Time.deltaTime;
        }

        if (transform.position.x < (player.transform.position.x) * 3 )
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
        }

        if (transform.position.y < (player.transform.position.y) * 3)
        {
            transform.position += new Vector3(0, speed) * Time.deltaTime;
        }

        if (transform.position.y > (player.transform.position.y) * 3 )
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
        }
    }
}

