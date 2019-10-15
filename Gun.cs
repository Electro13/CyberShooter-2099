using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Floats
    public float offset;

    //Editor
    public GameObject laserProjectile;
    public Transform laserSpawn;

    //Audio
    public AudioSource laserSFX;

    //Private
    private CameraShake shake;
    
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shake.CamShake();
            Instantiate(laserProjectile, laserSpawn.position, transform.rotation);
            laserSFX.Play();
        }
    }
}
