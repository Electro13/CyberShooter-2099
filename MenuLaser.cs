using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLaser : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Remove", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
