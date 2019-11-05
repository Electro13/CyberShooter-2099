using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // the bullet's speed
    float speed;
    // the direction of the bullet
    Vector2 _direction;
    // to know when the bullet's direction is set
    bool isReady;

    void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        // Set the direction normalized, to get a unit vector
        _direction = direction.normalized;

        // Set flag to true
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            // Get the bullet's current position
            Vector2 position = transform.position;

            // Compute the bullet's new position
            position += _direction * speed * Time.deltaTime;

            // Update the bullet's position
            transform.position = position;

            // Next we need to remove the bullet from our game
            // If the bullet goes outside the screen

            // This is the bottom-left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            // This is the top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // If the bullet goes outside the screen, then destroy it
            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision of an enemy's bullet with the player's ship
        if (collision.tag == "PlayerShipTag")
        {
            // Destroy this enemy's bullet
            Destroy(gameObject);
        }
    }
}
