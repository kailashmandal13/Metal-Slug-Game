using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Rigidbody2D bullet;
    public Transform[] shotSpawners;
    public float minYForce, maxYForce;
    public float fireRateMin, fireRateMax;

    public GameObject enemy;
    public Transform enemySpawn;
    public float minEnemyTime, maxEnemyTime;

    public int health;

    public GameObject laser;
    public Transform laserSpawn;
    public float minLaserTime, maxLaserTime;

    private bool isDead = false;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBoss()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
        Invoke("Fire", Random.Range(fireRateMin, fireRateMax));
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
        else
        {
            Debug.Log("Issue is there");
        }
        Invoke("InstantiateEnemies", Random.Range(minEnemyTime, maxEnemyTime));
        Invoke("FireLaser", Random.Range(minLaserTime, maxLaserTime));
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void InstantiateEnemies()
    {
        if(!isDead) {
            Instantiate(enemy, enemySpawn.position, enemySpawn.rotation);
            Invoke("InstantiateEnemies", Random.Range(minEnemyTime, maxEnemyTime));
        }
    }

    void Fire() 
    {
        if(!isDead) {
            Rigidbody2D tempBullet = Instantiate(bullet, shotSpawners[Random.Range(0, shotSpawners.Length)].position, Quaternion.identity); // Quaternion.identity significa sem rotação.
            tempBullet.AddForce(new Vector2(0, Random.Range(minYForce, maxYForce)), ForceMode2D.Impulse);
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
        else
        {
            Debug.Log("Issue is there");
        }
            Invoke("Fire", Random.Range(fireRateMin, fireRateMax));
        }
    }

    void FireLaser()
    {
        if(!isDead) {
            .
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
            Invoke("FireLaser", Random.Range(minLaserTime, maxLaserTime));
        }
    }

    public void TookDamage(int damage)
    {
        health -= damage; 
        if(health <= 0) {
            isDead = true;

            
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach(Enemy enemy in enemies) { 
                enemy.gameObject.SetActive(false); 
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
        else
        {
            Debug.Log("Issue is there");
        }
            
            Bullet[] bullets = FindObjectsOfType<Bullet>();
            foreach(Bullet bullet in bullets) { 
                bullet.gameObject.SetActive(false); 
            }

            Invoke("LoadScene", 2f);

        }else {
            StartCoroutine(TookDamageCoRoutine());
        }
    }

    IEnumerator TookDamageCoRoutine() 
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

}