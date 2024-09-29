using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathAnimation;
    public float attackDistance;
    public int health;
    public float speed;
    public GameObject coin;
    
    protected SpriteRenderer sprite;
    protected float targetDistance;
    protected Rigidbody2D rb2D;
    protected Animator anim;
    protected bool facinRight = true;
    protected Transform target;

    

    public void TookDamage(int damage)
    {
        health -= damage;
        if(health <= 0) {
            Instantiate(coin, transform.position, transform.rotation);
            Instantiate(deathAnimation, transform.position, transform.rotation);
            gameObject.SetActive(false);
        } else {
            StartCoroutine(TookDamageCoRoutine());
        }
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
        
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        targetDistance = transform.position.x - target.position.x;
    }

    protected void Flip() 
    {
        facinRight = !facinRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator TookDamageCoRoutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
