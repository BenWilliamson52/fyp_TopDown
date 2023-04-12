using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5trigger : MonoBehaviour
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
            link.triggerLink5 = true;
            Debug.Log("triggered 5");
            link.spawnOn5 = true;
            Debug.Log("spawning area 5");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

