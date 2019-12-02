using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceScoreSystem : MonoBehaviour
{
    public static int scoreCount = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreCount;
    }
}
