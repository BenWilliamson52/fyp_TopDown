using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level7trigger : MonoBehaviour
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
            link.triggerLink7 = true;
            Debug.Log("triggered 7");
            link.spawnOn7 = true;
            Debug.Log("spawning area 7");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

