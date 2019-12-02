using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpaceShip : MonoBehaviour
{
    // This is our player's bullet prefab
    public GameObject ShipLaser;

    // This is the spawn point for the player's bullet
    public GameObject BulletSpawn;

    // This is our explosion prefab
    public GameObject Explosion;

    public int playerSpeed = 10;
    public float playerJumpPower = 10;

    //Health Stats
    public int currentHealth;
    public int maxHealth = 100;

    //Audio
    public AudioSource laserSFX;
    public AudioSource takingDMGSFX;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
	}


    // Update is called once per frame
    void FixedUpdate ()
    {
        // if you press up or down, you go up or down
        // same thing for left and right
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, Input.GetAxisRaw("Vertical") * playerSpeed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = (GameObject)Instantiate(ShipLaser);
            Bullet.transform.position = BulletSpawn.transform.position;
            laserSFX.Play();
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision of the player ship with an enemy ship, or with an enemy bullet
        if ((collision.tag == "EnemyShipTag") || (collision.tag == "EnemyBulletTag") || (collision.tag == "ObstacleTag"))
        {          
            // Destroy the player's ship
            //Destroy(gameObject);
        }
    }

    public void PlayerShipTakeDamage(int dmg)
    {
        currentHealth -= dmg;
        takingDMGSFX.Play();
    }

    void Death()
    {
        PlayExplosion();
        Destroy(gameObject);
        SceneManager.LoadScene("Defeat");
    }

    // Function to instantiate an explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        // Set the position of an explosion
        explosion.transform.position = transform.position;
    }


}
