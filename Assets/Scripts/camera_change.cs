using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_change : MonoBehaviour
{

    public GameObject Cam;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;
    
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cam.gameObject.SetActive(true);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
        }

         if (collision.gameObject.tag == "Ruhe")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(true);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
        }

         if (collision.gameObject.tag == "Hangin")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(true);
            Cam4.gameObject.SetActive(false);
        }

         if (collision.gameObject.tag == "Kalju")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(true);
        }
    }   

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Ruhe")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Hangin")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Kalju")
        {
            Cam.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
        }
    }

}
