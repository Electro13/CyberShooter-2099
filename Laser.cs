using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed;
    public float laserLifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroys laser prefab after set time
        Invoke("DestroyLaser", laserLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * laserSpeed * Time.deltaTime);
    }

    void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
