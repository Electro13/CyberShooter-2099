using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretV2 : MonoBehaviour
{
    //Ints
    public int turretHP = 100;
    public int dmgPoints = 10;

    //Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;
    public float timeBetweenShots;
    //Bools
    public bool isAwake = false;
    public bool lookingRight = true;
    public bool isShooting;
    //Editor
    SpriteRenderer turretSR;
    public GameObject projectileV2;
    public Transform target;
    public Transform shootLeft;
    public Transform shootRight;
    private UnityEngine.Object explosionRef;

    //Audio
    public AudioSource beingHitSFX;

    //Materials
    private Material matFlash;
    private Material matDefault;

    void Awake()
    {
        turretSR = GetComponent<SpriteRenderer>();
        isShooting = false;
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
        RangeCheck();

        if(target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if(target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
    }

    //Material resets to default
    void ResetMaterial()
    {
        turretSR.material = matDefault;
    }

    void RangeCheck()
    {
        //Checking the distance between player and turret
        distance = Vector3.Distance(transform.position, target.transform.position);

        //If player is within distance of turret, it is now activated
        if (distance < wakeRange)
        {
            turretSR.flipX = true;
            isAwake = true;


            if (isShooting == true)
            {
                timeBetweenShots -= Time.deltaTime;
                if (timeBetweenShots <= 0f)
                {
                    //Shoot();
                    timeBetweenShots = 2f;
                }
            }
        }

        //If player is outisde of distance, turret is deactivated
        if(distance > wakeRange)
        {
            turretSR.flipX = false;
            isAwake = false;
        }
    }

    //public void Attack(bool attackingRight)
    //{
    //    bulletTimer += Time.deltaTime;
    //    if(bulletTimer >= shootInterval)
    //    {
    //        Vector2 direction = target.transform.position - transform.position;
    //        direction.Normalize();
    //        if(!attackingRight)
    //        {
    //            /*GameObject bulletClone;
    //            bulletClone = Instantiate(projectileV2, shootLeft.transform.position, shootLeft.transform.rotation);
    //            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;*/
    //            //Instantiate(projectileV2, shootLeft.position, shootLeft.rotation);
    //            bulletTimer = 0;
    //        }

    //        if (attackingRight)
    //        {
    //            /*GameObject bulletClone;
    //            bulletClone = Instantiate(projectileV2, shootRight.transform.position, shootRight.transform.rotation);
    //            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;*/
    //            //Instantiate(projectileV2, shootRight.position, shootRight.rotation);
    //            bulletTimer = 0;
    //        }
    //    }
    //}

    public void Shoot(bool isShooting)
    {
        Instantiate(projectileV2, shootLeft.position, shootLeft.rotation);
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
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
        }
    }
}
