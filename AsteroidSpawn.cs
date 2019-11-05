using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject Asteroid;

    float maxSpawnRateInSeconds = 7f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAsteroid", maxSpawnRateInSeconds);

        //Increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Instantiate an asteroid
        GameObject anAsteroid = (GameObject)Instantiate(Asteroid);
        anAsteroid.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //Schedule when to spawn the next enemy
        ScheduleNextAsteroidSpawn();
    }

    void ScheduleNextAsteroidSpawn()
    {
        float SpawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            //pick a number between 1 and maxSpawnRateInSeconds
            SpawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            SpawnInNSeconds = 1f;

        Invoke("SpawnAsteroid", SpawnInNSeconds);
    }

    //Function to increase the difficulty of the game
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
