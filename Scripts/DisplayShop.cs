using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShop : MonoBehaviour
{
    public GameObject shopPanel;

    void OnTriggerEnter2D(Collider2D collider) 
    {
        Player player = collider.GetComponent<Player>();

        if(player != null) {
            player.canFire = false;
            Debug.Log("No issue is there");
            shopPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider) 
    {
        Player player = collider.GetComponent<Player>();
        
        if(player != null) {
            player.canFire = true;
            Debug.Log("No issue is there");
            shopPanel.SetActive(false);
        }
    }
}