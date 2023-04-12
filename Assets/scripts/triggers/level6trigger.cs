using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level6trigger : MonoBehaviour
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
            link.triggerLink6 = true;
            Debug.Log("triggered 6");
            link.spawnOn6 = true;
            Debug.Log("spawning area 6");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

