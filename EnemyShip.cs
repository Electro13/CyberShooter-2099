using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    //Floats
    public float dmgPoints = 5f;
    public float walkSpeed = 5f;
    //Ints
    public int shipHP = 100;
    //Bool
    public bool isFacingRight = true;
    //Editor
    public Rigidbody2D rb;
    SpriteRenderer shipSR;
    private UnityEngine.Object explosionRef;
    //Materials
    private Material matFlash;
    private Material matDefault;
    //Audio
    public AudioSource beingHitSFX;

    // Start is called before the first frame update
    void Start()
    {
        shipSR = GetComponent<SpriteRenderer>();
        matFlash = Resources.Load("Flash", typeof(Material)) as Material;
        matDefault = shipSR.material;
        explosionRef = Resources.Load("EnemyExplosion");
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure Rigidbody2D is attached before doing stuff
        if (rb)
        {
            if (!isFacingRight)
            {
                // Makes the player move left
                rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
            }
            else
            {
                // Makes the player move right
                rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy will damage player on collision
        if (collision.CompareTag("Player"))
        {
            HealthSystem.health -= dmgPoints;
        }
        //When enemy reaches a wallcollider he will flip
        if (collision.gameObject.tag == "WallCollider")
        {
            flip();
        }
        //Checking to see it's being hit by laser projectile
        if (collision.CompareTag("Projectile"))
        {
            Debug.Log("Enemy is being damaged.");
            //When hit by laser projectile, change colour
            shipSR.material = matFlash;
            //Reset material after .1 seconds
            Invoke("ResetMaterial", 0.1f);
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
        }
    }
    //Material resets to default
    void ResetMaterial()
    {
        shipSR.material = matDefault;
    }

    //Take Damage from Player's Gun
    public void TakeDamage(int damage)
    {
        beingHitSFX.Play();
        shipHP -= damage;
        if (shipHP <= 0)
        {
            ScoreCounter.scoreValue += 10;
            Destroy(gameObject);
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
        }
    }

    //Flip when moving left and right
    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;
        transform.localScale = scaleFactor;
    }
}
