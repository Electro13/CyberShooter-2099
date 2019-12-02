using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2FinalBoss : MonoBehaviour
{
    public int bossCurrentHealth;
    public int bossMaxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        bossMaxHealth = bossCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCurrentHealth > bossMaxHealth)
        {
            bossCurrentHealth = bossMaxHealth;
        }

        if (bossCurrentHealth <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBulletTag"))
        {
            //bossCurrentHealth -= 
        }
    }

    public void BossShipTakeDamage(int dmg)
    {
        bossCurrentHealth -= dmg;
        //takingDMGSFX.Play();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
