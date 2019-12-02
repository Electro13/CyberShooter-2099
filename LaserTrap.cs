using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public float laserKill = 1000;
    public float trapTimer = 2;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isActive)
        //{
        //    trapTimer -= Time.deltaTime;
        //    if (trapTimer <= 0f)
        //    {
        //        gameObject.SetActive(false);
        //        isActive = false;

        //        if (trapTimer == 0f)
        //        {
        //            trapTimer += Time.deltaTime;
        //            isActive = true;
        //            gameObject.SetActive(true);
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            HealthSystem.health -= laserKill;
        }
    }

}
