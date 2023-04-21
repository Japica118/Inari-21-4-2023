using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHidden : MonoBehaviour
{

    public GameObject Cam;
    public GameObject Icon;
    void OnTriggerStay(Collider collision)
    {
        Icon.gameObject.SetActive(true);
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {
            Cam.gameObject.SetActive(true);
        }

         if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Cam.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Icon.gameObject.SetActive(false);
        if (collision.gameObject.tag == "Player")
        {
            Cam.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Ruhe")
        {
            Cam.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Hangin")
        {
            Cam.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Kalju")
        {
            Cam.gameObject.SetActive(false);
        }
    }

}


