using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4trigger : MonoBehaviour
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
            link.triggerLink4 = true;
            Debug.Log("triggered 4");
            link.spawnOn4 = true;
            Debug.Log("spawning area 4");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
