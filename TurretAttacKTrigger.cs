using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttacKTrigger : MonoBehaviour
{
    private EnemyTurretV2 t2;
    public bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        t2 = GetComponent<EnemyTurretV2>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(isLeft)
            {
                t2.Shoot(false);
            }
            else
            {
                t2.Shoot(true);
            }
        }
    }
}
