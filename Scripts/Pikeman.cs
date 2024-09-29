using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikeman : Enemy
{
    public float walkDistance;

   
    private bool attack = false;
    private bool walk;
    
    void Start()
    {
        
    }

    
    protected override void Update()
    {
        base.Update();

        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);

        if(Mathf.Abs(targetDistance) < walkDistance) {
            walk = true;
        }

        if(Mathf.Abs(targetDistance) < attackDistance) {
            attack = true;
            walk = false;
        }
    }

    private void FixedUpdate() 
    {
        if(walk && !attack) {
            if(targetDistance < 0) { 
                rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
                if(!facinRight) {
                    Flip();
                }
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
                
            }else { 
                rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
                if(facinRight) {
                    Flip();
                }
            }
        }
    }

    public void ResetAttack()
    {
        attack = false; 
    }
}