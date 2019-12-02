using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipHUD : MonoBehaviour
{
    public Sprite[] HealthSprites;
    public Image healthUI;
    private PlayerSpaceShip player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShipTag").GetComponent<PlayerSpaceShip>();
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.sprite = HealthSprites[player.currentHealth];
    }
}
