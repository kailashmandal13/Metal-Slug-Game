using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D collider) 
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}