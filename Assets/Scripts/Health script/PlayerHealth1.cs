using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealthBar playerHealthBar;
    // Start is called before the first frame update
    void Start()
    {

        GameObject healthObject = GameObject.Find("PlayerHealthBar");

        playerHealthBar = healthObject.GetComponentInChildren<PlayerHealthBar>();

        Time.timeScale = 1;
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0 )
        {
            Time.timeScale = 0;


            playerHealthBar.SetMaxHealth(maxHealth);
          
            Debug.Log("Game Over!");
        


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.CompareTag("Enemy"))
        {

            //ScoreManager.scoreValue += 100;
            TakeDamage(10);
            

        }
    }

    }
