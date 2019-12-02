using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    private UnityEngine.Object explosionRef;

    private void Start()
    {
        explosionRef = Resources.Load("CoinExplosion");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Add score by 10 from accessing ScoreCounter script
            ScoreCounter.scoreValue += 10;
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y + .3f);
            //Destroy coin object
            Destroy(gameObject);
        }
    }
}
