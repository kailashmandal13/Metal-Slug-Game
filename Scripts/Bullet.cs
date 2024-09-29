using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private int damage = 1;
    public float speed = 10;
    public float destroyTime = 1.5f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
        Debug.Log("Issue persists");
        damage = GameManager.gameManager.damage;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        Enemy otherEnemy = collider.GetComponent<Enemy>();
        Boss boss = collider.GetComponent<Boss>();
        Debug.Log("Issue persists");

        if(otherEnemy != null) {
            otherEnemy.TookDamage(damage);
        }

        if(boss != null) {
            boss.TookDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
