using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public Transform shotSpawner;
    public Rigidbody2D bomb;
    public float damageTime = 1f;
    public float jumpForce = 600;
    public GameObject bulletPrefab;
    public bool canFire = true;

    private Animator anim;

    private bool onGround = false;
    private Transform groundCheck;
    private float nextFire;
    private float hForce = 0;
    private bool isDead = false;
    private bool crouched;
    private bool lookingUp;
    private bool reloading;
    private Rigidbody2D rb2D;
    private bool facinRight = true;
    private bool jump;
    private float fireRate = 0.5f;
    private bool tookDamage = false;
    private int health;
    private int maxHealth;
    private int bullets;
    private float reloadTime;
    private int bombs;

    GameManager gameManager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        gameManager = GameManager.gameManager;

        SetPlayerStatus();
        bombs = gameManager.bombs;
        health = maxHealth;

        UpdateBulletsUI();
        UpdateBombsUI();
        UpdateHealthUI();
    }

    void Update()
    {
        if (!isDead)
        {
            onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

            if (onGround)
            {
                anim.SetBool("jump", false);
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

            if (Input.GetButtonDown("Jump") && onGround && !reloading)
            {
                jump = true;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (rb2D.velocity.y > 0)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
                }
            }

            if (Input.GetButtonDown("Fire1") && Time.time > nextFire && bullets > 0 && !reloading && canFire)
            {
                nextFire = Time.time + fireRate;
                anim.SetTrigger("shoot");
                GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
                if (!facinRight && !lookingUp)
                {
                    tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
                }
                else if (!facinRight && lookingUp)
                {
                    tempBullet.transform.eulerAngles = new Vector3(0, 0, 90);
                }
                if (crouched && !onGround)
                {
                    tempBullet.transform.eulerAngles = new Vector3(0, 0, -90);
                }

                bullets--;
                UpdateBulletsUI();
            }
            else if (Input.GetButtonDown("Fire1") && bullets <= 0 && onGround)
            {
                StartCoroutine(Reloading());
            }

            lookingUp = Input.GetButton("Up");
            crouched = Input.GetButton("Down");

            anim.SetBool("lookingUp", lookingUp);
            anim.SetBool("crouched", crouched);

            if (Input.GetButtonDown("Fire2") && bombs > 0)
            {
                Rigidbody2D tempBomb = Instantiate(bomb, transform.position, transform.rotation);
                if (facinRight)
                {
                    tempBomb.AddForce(new Vector2(8, 10), ForceMode2D.Impulse);
                }
                else if (!facinRight)
                {
                    tempBomb.AddForce(new Vector2(-8, 10), ForceMode2D.Impulse);
                }

                bombs--;
                UpdateBombsUI();
            }

            if (Input.GetButtonDown("Reload") && onGround)
            {
                StartCoroutine(Reloading());
            }

            if ((crouched || lookingUp || reloading) && onGround)
            {
                hForce = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (!crouched && !lookingUp && !reloading)
            {
                hForce = Input.GetAxisRaw("Horizontal");
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

            anim.SetFloat("speed", Mathf.Abs(hForce));

            rb2D.velocity = new Vector2(hForce * speed, rb2D.velocity.y);

            if (hForce > 0 && !facinRight)
            {
                Flip();
            }
            else if (hForce < 0 && facinRight)
            {
                Flip();
            }

            if (jump)
            {
                anim.SetBool("jump", true);
                jump = false;
                rb2D.AddForce(Vector2.up * jumpForce);
            }
        }
    }

    IEnumerator Reloading()
    {
        reloading = true;
        anim.SetBool("reloading", true);
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
        yield return new WaitForSeconds(reloadTime);
        bullets = gameManager.bullets;
        reloading = false;
        anim.SetBool("reloading", false);
        UpdateBulletsUI();
    }

    IEnumerator TookDamage()
    {
        tookDamage = true;
        health--;
        UpdateHealthUI();
        if (health <= 0)
        {
            isDead = true;
            anim.SetTrigger("death");
            Invoke("ReloadScene", 2f);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10);
            for (float i = 0; i < damageTime; i += 0.2f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
            Physics2D.IgnoreLayerCollision(9, 10, false);
            tookDamage = false;
        }
    }

    void Flip()
    {
        facinRight = !facinRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetHealthAndBombs(int life, int bomb)
    {
        health += life;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        bombs += bomb;
        UpdateBombsUI();
        UpdateHealthUI();
    }

    public void SetPlayerStatus()
    {
        fireRate = gameManager.fireRate;
        bullets = gameManager.bullets;
        reloadTime = gameManager.realoadTime;
        maxHealth = gameManager.health;
    }



    void UpdateBombsUI()
    {
        FindObjectOfType<UIManager>().UpdateBombs(bombs);
        gameManager.bombs = bombs;
    }

    void UpdateBulletsUI()
    {
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
        FindObjectOfType<UIManager>().UpdateBulletsUI(bullets);
    }

    void UpdateCoinsUI()
    {
        FindObjectOfType<UIManager>().UpdateCoins();
    }

    void UpdateHealthUI()
    {
        FindObjectOfType<UIManager>().UpdateHealthUI(health);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !tookDamage)
        {
            StartCoroutine(TookDamage());
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameManager.coins += 1;
            UpdateCoinsUI();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") && !tookDamage)
        {
            StartCoroutine(TookDamage());
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
        if (collider.CompareTag("Lava"))
        {
            Debug.Log("Time to dieeeee");
            isDead = true;
            anim.SetTrigger("death");
            Invoke("ReloadScene", 2f);
        }
    }


}
