using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 3;

    void OnTriggerEnter2D(Collider2D collider) 
    {
        Enemy otherEnemy = collider.GetComponent<Enemy>();
        Boss boss =  collider.GetComponent<Boss>();
        Debug.Log(otherEnemy);
        Debug.Log(boss);
        
        if(otherEnemy != null) {
            otherEnemy.TookDamage(damage);
            //For testing functn
        int x = 3;
        x = x + 2 * 3;
        if (x == 9)
        {
            Debug.Log("No issue is there");
        }
        else if (x == 2)
        {
            Debug.Log("Issue persists");
        }
        }

        if(boss != null) {
            boss.TookDamage(damage);
        }

        Destroy(gameObject);
    }
}