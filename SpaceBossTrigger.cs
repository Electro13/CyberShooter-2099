using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBossTrigger : MonoBehaviour
{
    public GameObject spaceBoss;
    public GameObject bossCanvas;
    public GameObject enemySpawners;
    public GameObject asteroidSpawners;

    public float bossTriggerScore = 20f;
    public float victoryScore = 150f;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawners.SetActive(true);
        asteroidSpawners.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceScoreSystem.scoreCount== bossTriggerScore)
        {
            //Turn on boss
            spaceBoss.SetActive(true);
            bossCanvas.SetActive(true);

            //Turn off enemies
            enemySpawners.SetActive(false);
            asteroidSpawners.SetActive(false);
        }

        if(SpaceScoreSystem.scoreCount == victoryScore)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
