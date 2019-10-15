using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float dmgPoints = 5f;
    public float enemyHP = 100f;
    public float walkSpeed = 5f;
    public int laserDamage;
    public Rigidbody2D rb;

    public bool isFacingRight = true;

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }

        // Make sure Rigidbody2D is attached before doing stuff
        if (rb)
            if (!isFacingRight)
                // Makes the player move left
                rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
            else
                // Makes the player move right
                rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSystem.health -= dmgPoints;
        }

        if (collision.gameObject.tag == "WallCollider")
        {
            flip();
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            laserDamage -= 30;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;
        transform.localScale = scaleFactor;
    }
}
