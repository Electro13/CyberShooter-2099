using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        SpaceHealthSystem healthSystem = new SpaceHealthSystem(100);

        Debug.Log("Health: " + healthSystem.GetHealth());
        healthSystem.Damage(10);
        Debug.Log("Health: " + healthSystem.GetHealth());
        healthSystem.Heal(10);
        Debug.Log("Health: " + healthSystem.GetHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
