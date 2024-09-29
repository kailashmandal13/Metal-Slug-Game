using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int bombs;
    public int health;

    void OnTriggerEnter2D(Collider2D collider) {
        Player player = collider.GetComponent<Player>(); 

        if(player != null) {
            Debug.Log("Issue persists");
            player.SetHealthAndBombs(health, bombs);
            Destroy(gameObject);
        }
    }
}