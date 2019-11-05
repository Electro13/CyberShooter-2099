using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    //Editor
    public GameObject laserProjectile;
    public Transform laserSpawn;

    //Audio
    public AudioSource laserSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserProjectile, laserSpawn.position, laserSpawn.rotation);
            laserSFX.Play();
        }
    }
}
