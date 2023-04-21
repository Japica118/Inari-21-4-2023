using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Tienda : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    private bool isPlayerInsideTrigger = false;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ruhe") || collision.gameObject.CompareTag("Hangin") || collision.gameObject.CompareTag("Kalju"))
        {
            isPlayerInsideTrigger = true;
        }

        if (isPlayerInsideTrigger && Input.GetButtonDown("Submit"))
        {
            shopCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopCanvas.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ruhe") || collision.gameObject.CompareTag("Hangin") || collision.gameObject.CompareTag("Kalju"))
        {
            isPlayerInsideTrigger = false;
        }
    }
}