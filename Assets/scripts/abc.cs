using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abc : MonoBehaviour
{
    private void OnTriggerEnter2D2(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLayer collided");
        }
    }
}