using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    public float fireRate;
    public Transform shotSpawner;
    public GameObject bulletPrefab;

    private float nextFire;

    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();

        if(targetDistance < 0) {
            if(!facinRight) {
                Flip();
            }
        }else {
            if(facinRight) {
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
        }

        if(Mathf.Abs(targetDistance) < attackDistance && Time.time > nextFire) {
            anim.SetTrigger("Shooting");
            nextFire = Time.time + fireRate;
        }
    }

    public void Shooting()
    {
        GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        if(!facinRight) {
            tempBullet.transform.eulerAngles = new Vector3(0,0,180); 
        }
    }
}