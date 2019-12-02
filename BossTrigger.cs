using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private Slider bossCanvas;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject boxColliderEnable;
    public GameObject boss;
    public GameObject bossUI;
    public GameObject lplatform1, lplatform2;
    public GameObject splatform1, splatform2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bossCanvas.enabled = true;
        }

        camera1.SetActive(false);
        camera2.SetActive(true);
        boxColliderEnable.SetActive(true);
        boss.SetActive(true);
        bossUI.SetActive(true);
        lplatform1.SetActive(true);
        lplatform2.SetActive(true);
        splatform1.SetActive(true);
        splatform2.SetActive(true);
    }
}
