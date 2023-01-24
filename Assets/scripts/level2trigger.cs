using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2trigger : MonoBehaviour
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
            link.triggerLink = true;
            Debug.Log("triggered");
            link.spawnOn2 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
