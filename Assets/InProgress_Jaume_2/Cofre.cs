using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private GameObject chestIcon;
    [SerializeField] private GameObject chestIcon2;
    [SerializeField] private GameObject chestIcon3;
    [SerializeField] private GameObject chestIcon4;
    [SerializeField] private AudioClip openChest;
    [SerializeField] private AudioClip chestAlert;
    /*[SerializeField] private AvrosManager avrosManager;
    [SerializeField] private int minAvros = 5;
    [SerializeField] private int maxAvros = 10;*/

    private bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (!isOpened && collider.gameObject.CompareTag("Player"))
        {
            chestIcon.SetActive(true);
            audio.PlayOneShot(chestAlert);
        }

         if (!isOpened && collider.gameObject.CompareTag("Ruhe"))
        {
            chestIcon2.SetActive(true);
            audio.PlayOneShot(chestAlert);
        }

         if (!isOpened && collider.gameObject.CompareTag("Hangin"))
        {
            chestIcon3.SetActive(true);
            audio.PlayOneShot(chestAlert);
        }

         if (!isOpened && collider.gameObject.CompareTag("Kalju"))
        {
            chestIcon4.SetActive(true);
            audio.PlayOneShot(chestAlert);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (!isOpened && collider.gameObject.CompareTag("Player") && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("isOpen", true);
            chestIcon.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Ruhe") && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("isOpen", true);
            chestIcon2.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Hangin") && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("isOpen", true);
            chestIcon3.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Kalju") && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("isOpen", true);
            chestIcon4.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            anim.SetBool("isOpen", true);
            chestIcon.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Ruhe") && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            anim.SetBool("isOpen", true);
            chestIcon2.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Hangin") && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            anim.SetBool("isOpen", true);
            chestIcon3.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }

        if (!isOpened && collider.gameObject.CompareTag("Kalju") && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            anim.SetBool("isOpen", true);
            chestIcon4.SetActive(false);
            /*int avrosAmount = Random.Range(minAvros, maxAvros + 1);
            avrosManager.AddAvrosFromChest(avrosAmount);*/
            isOpened = true;
            audio.PlayOneShot(openChest);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (!isOpened && collider.gameObject.CompareTag("Player"))
        {
            chestIcon.SetActive(false);
        }

        if (!isOpened && collider.gameObject.CompareTag("Ruhe"))
        {
            chestIcon2.SetActive(false);
        }

        if (!isOpened && collider.gameObject.CompareTag("Hangin"))
        {
            chestIcon3.SetActive(false);
        }

        if (!isOpened && collider.gameObject.CompareTag("Kalju"))
        {
            chestIcon4.SetActive(false);
        }
    }

}