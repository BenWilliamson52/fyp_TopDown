using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int points = 10; // these are placeholder points and will be replaced with amount of enemies killed

    public gameover gameover;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Debug.Log("collided with enemy 1");
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            //SceneManager.LoadScene("mainMenu");
            gameover.Setup(points);
        }

        if (collision.gameObject.CompareTag("Enemy2"))
        {
            Debug.Log("collided with enemy 2");
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            //SceneManager.LoadScene("mainMenu");
            gameover.Setup(points);
        }

    }
}


