using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public int dmg = 200;
    public float timer = 3f;
    bool isDead;

    void Start()
    {
        //Player is not dead till he touches the acid water/deathzone
        isDead = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If deathzone collides with player
        if(collision.CompareTag("Player"))
        {
            //Instantly destroy
            HealthSystem.health -= dmg;
            //Player is now dead
            isDead = true;
        }
    }
    void Update()
    {
        //Since player is dead
        if(isDead == true)
        {
            //Countdown from 3 seconds
            timer -= Time.deltaTime;
            //Timer is now 0
            if (timer < 0)
            {
                //Reload level 1
                SceneManager.LoadScene("level01");
            }
        }

    }
}
