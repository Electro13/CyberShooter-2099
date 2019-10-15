using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    Image healthbar;
    public float maxHealth = 100f;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / maxHealth;
    }
}
