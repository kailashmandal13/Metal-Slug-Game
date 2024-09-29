using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public int coins;
    public int damage = 1;
    public float fireRate = 0.5f;
    public int upgradeCost = 20;
    public float reloadTime = 1f;
    public int bullets = 6;
    public int health = 5;
    public int bombs = 2;
    

    public static GameManager gameManager;

    void Awake()
    {
        if(gameManager == null) {
            gameManager = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
