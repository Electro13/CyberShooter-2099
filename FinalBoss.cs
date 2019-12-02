using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    //Ints
    public int bossHP = 1000;

    //Floats
    public float dmgPoints = 25;

    //Editor
    Rigidbody2D bossRB;
    SpriteRenderer bossSR;
    private UnityEngine.Object explosionRef;

    //Materials
    private Material matFlash;
    private Material matDefault;

    //Audio
    public AudioSource beingHitSFX;

    //UI
    public Slider bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        bossSR = GetComponent<SpriteRenderer>();
        matFlash = Resources.Load("BossFlash", typeof(Material)) as Material;
        matDefault = bossSR.material;
        explosionRef = Resources.Load("Boss_PS");
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthBar.value = bossHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Boss will damage player on collision
        if (collision.CompareTag("Player"))
        {
            HealthSystem.health -= dmgPoints;
        }
        //Checking to see it's being hit by laser projectile
        if (collision.CompareTag("Projectile"))
        {
            Debug.Log("Enemy is being damaged.");
            //When hit by laser projectile, change colour
            bossSR.material = matFlash;
            //Reset material after .1 seconds
            Invoke("ResetMaterial", 0.2f);
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
        }
    }

    //Material resets to default
    void ResetMaterial()
    {
        bossSR.material = matDefault;
    }

    //Take Damage from Player's Gun
    public void TakeDamage(int damage)
    {
        beingHitSFX.Play();
        bossHP -= damage;
        if (bossHP <= 0)
        {
            ScoreCounter.scoreValue += 100;
            Destroy(gameObject);
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
            SceneManager.LoadScene("Victory");
        }
    }
}
