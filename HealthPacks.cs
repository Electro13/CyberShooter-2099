using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPacks : MonoBehaviour
{
    public static float hpBonus = 25;
    private UnityEngine.Object hpRef;
    void Start()
    {
        //hpSystem = GetComponent<HealthSystem>();
        hpRef = Resources.Load("HP Particle System");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            HealthSystem.health += hpBonus;
            //Spawn Particle System Effect
            GameObject explosion = (GameObject)Instantiate(hpRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y - .3f);
            Destroy(gameObject);
        }
    }
}
