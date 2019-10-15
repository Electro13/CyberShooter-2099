using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int laserDamage = 30;
    //public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Remove", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void Remove()
    {
        //play effect
        //instanitate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
