using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    Rigidbody2D rb;
    public int turretProjectileDamage = 20;
    Player target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        int FlipFlop = 1;
        if (moveDirection.x > 0)
        {
            FlipFlop = 1;
        }
        else if (moveDirection.x < 0)
        {
            FlipFlop = -1;
        }
        rb.velocity = new Vector2(moveSpeed * FlipFlop, 0);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Turret Projectile Hit Player");
            Destroy(gameObject);
            HealthSystem.health -= turretProjectileDamage;
        }        
    }
}
