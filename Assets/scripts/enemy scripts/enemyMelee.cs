using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMelee : MonoBehaviour
{
    //public GameObject lookingPlayer;
    //public float lookingSpeed;
    //public float rotationModifier;

    public GameObject player;
    public Rigidbody2D rb;
    //public GameObject Manager;
    //public playerMovement player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        //lookingPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMoveMelee();

        //if (lookingPlayer != null)
        //{
        //    Vector3 vectorToTarget = lookingPlayer.transform.position - transform.position;
        //    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        //    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * lookingSpeed);
        //}



    }

    public void EnemyMoveMelee()
    {
        if(transform.position.x > player.transform.position.x)
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
            transform.position -= new Vector3(0, speed) *Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            gameManager.instance.Addpoint();
        }
    }
}
