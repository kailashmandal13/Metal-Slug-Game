using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player")) {
            FindObjectOfType<Boss>().ActivateBoss();
            Debug.Log("Issue persists");
            FindObjectOfType<UnityStandardAssets._2D.CameraFollow>().minXAndY = new Vector2(117.5f, 0);
            gameObject.SetActive(false);
        }
    }
}
