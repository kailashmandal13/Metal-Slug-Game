using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text bulletsText;
    public Text coinsText;
    public Text bombsText;
    public Text healthText;
    public Slider healthBar;

    void Start()
    {
        UpdateHealthBar();
        UpdateCoins();
    }

    public void UpdateBulletsUI(int bullets)
    {
        bulletsText.text = bullets.ToString();
    }

    public void UpdateHealthUI(int health)
    {
        healthText.text = health.ToString();
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
        healthBar.value = health; 
    }

    public void UpdateBombs(int bombs)
    {
        bombsText.text = bombs.ToString();
    }

    public void UpdateCoins()
    {
        coinsText.text = GameManager.gameManager.coins.ToString();
    }

    
    public void UpdateHealthBar()
    {
        Debug.Log("Health: " + GameManager.gameManager.health);
        healthBar.maxValue = GameManager.gameManager.health;
    }
}