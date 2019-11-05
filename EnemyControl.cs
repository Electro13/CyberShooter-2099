using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // This is our explosion prefab
    public GameObject Explosion;

    float speed; //for the enemy speed

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f; //set speed
    }

    // Update is called once per frame
    void Update()
    {
        //Get the enemy's current position
        Vector2 position = transform.position;

        //Compute the enemy's new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update the enemy's position
        transform.position = position;

        //This is the bottom left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //If the enemy went outside the screen on the bottom, then destroy the enemy
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision with the enemy's ship with the player's ship, or with the player's bullet
        if ((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            //Destroy this enemy ship
            Destroy(gameObject);
        }
    }

    // Function to Instantiate an explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        // Set the position of the explosion
        explosion.transform.position = transform.position;
    }
}
