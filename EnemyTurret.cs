using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    //Floats
    float Timer = 2f;

    //Ints
    public int turretHP = 100;
    public int dmgPoints = 10;

    //Editor
    public Transform target;
    SpriteRenderer turretSR;
    public Transform spawn;
    public GameObject projectile;
    private UnityEngine.Object explosionRef;

    //Audio
    public AudioSource beingHitSFX;

    //Materials
    private Material matFlash;
    private Material matDefault;

    //Bools
    public bool facingLeft;
    public bool canShoot;

    public static EnemyTurret Instance;

    void Awake()
    {
        turretSR = GetComponent<SpriteRenderer>();
        facingLeft = true;
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        turretSR = GetComponent<SpriteRenderer>();
        matFlash = Resources.Load("Flash", typeof(Material)) as Material;
        matDefault = turretSR.material;
        explosionRef = Resources.Load("EnemyExplosion");
    }

    // Update is called once per frame
    void Update()
    {

        if (canShoot == true)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {
                Shoot();
                Timer = 2f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canShoot = true;
            HealthSystem.health -= dmgPoints;
        }

        //Checking to see it's being hit by laser projectile
        if (collision.CompareTag("Projectile"))
        {
            Debug.Log("Turret is being damaged.");
            //When hit by laser projectile, change colour
            turretSR.material = matFlash;
            //Reset material after .1 seconds
            Invoke("ResetMaterial", 0.1f);
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
        }

        if (facingLeft == true)
        {
            this.turretSR.flipX = target.transform.position.x < this.transform.position.x;
            facingLeft = false;
        }

        else
        {
            this.turretSR.flipX = target.transform.position.x < this.transform.position.x;
            facingLeft = true;
        }
    }

    //Material resets to default
    void ResetMaterial()
    {
        turretSR.material = matDefault;
    }

    void Shoot()
    {
        if (facingLeft == true)
        {
            Instantiate(projectile, spawn.position, spawn.rotation);
        }

        else
        {
            Instantiate(projectile, spawn.position, spawn.rotation);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canShoot = false;
        }
    }

    //Take Damage from Player's Gun
    public void TakeDamage(int damage)
    {
        beingHitSFX.Play();
        turretHP -= damage;
        if (turretHP <= 0)
        {
            ScoreCounter.scoreValue += 15;
            Destroy(gameObject);
            //play particle system
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
        }
    }
}
