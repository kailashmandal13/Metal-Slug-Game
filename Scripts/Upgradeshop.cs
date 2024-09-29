using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public Text healthText;
    public Text reloadTimeText;
    public Text upgradeCostText;
    public Text damageText;
    public Text fireRateText;
    public Text bulletsText;
    

    GameManager gameManager;
    Player player;

    void Start()
    {
        gameManager = GameManager.gameManager;
        player = FindObjectOfType<Player>();
        UpdateUI();
    }

    void UpdateUI()
    {
        bulletsText.text = "Bullets: " + gameManager.bullets;
        reloadTimeText.text = "Reload Time: " + gameManager.realoadTime;
        healthText.text = "Health: " + gameManager.health;
        damageText.text = "Damage: " + gameManager.damage;
        fireRateText.text = "Fire Rate: " + gameManager.fireRate;
        upgradeCostText.text = "Upgrade Cost: " + gameManager.upgradeCost;
    }

    void SetCoins(int coin)
    {
        gameManager.coins -= coin;
        FindObjectOfType<UIManager>().UpdateCoins();
    }

    public void SetHealth()
    {
        
        if(gameManager.coins >= gameManager.upgradeCost) {
            gameManager.health++;
            FindObjectOfType<UIManager>().UpdateHealthBar();
            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
            gameManager.upgradeCost += (gameManager.upgradeCost / 5); 
            UpdateUI();
        }
    }

    

    public void SetFireRate()
    {

        if(gameManager.coins >= gameManager.upgradeCost) {
            gameManager.fireRate -= 0.1f;

            if(gameManager.fireRate <= 0) {
                gameManager.fireRate = 0;
            }

            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
            gameManager.upgradeCost += (gameManager.upgradeCost / 5);
            UpdateUI();
        }
    }

    public void SetDamage()
    {
        
        if(gameManager.coins >= gameManager.upgradeCost) {
            gameManager.damage++;
            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
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
            gameManager.upgradeCost += (gameManager.upgradeCost / 5);
            UpdateUI();
        }
    }

    public void SetReloadTime()
    {
        
        if(gameManager.coins >= gameManager.upgradeCost) {
            gameManager.realoadTime -= 0.1f;

            if(gameManager.realoadTime <= 0) {
                gameManager.realoadTime = 0;
            }

            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
            gameManager.upgradeCost += (gameManager.upgradeCost / 5);
            UpdateUI();
        }
    }

    public void SetBullets()
    {
        
        if(gameManager.coins >= gameManager.upgradeCost) {
            gameManager.bullets++;
            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
            gameManager.upgradeCost += (gameManager.upgradeCost / 5);
            UpdateUI();
        }
    }

    
}