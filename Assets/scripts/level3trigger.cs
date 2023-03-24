using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3trigger : MonoBehaviour
{
    public gameManager link;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            link.triggerLink3 = true;
            Debug.Log("triggered 3");
            link.spawnOn3 = true;
            Debug.Log("spawning area 3");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
