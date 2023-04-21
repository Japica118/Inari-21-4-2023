using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
/*{

    Animator anim;
    [SerializeField] private GameObject doorMark;
    private SFXManager sfxManager;

    private bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("Open", true);
            sfxManager.DoorSound();
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            anim.SetBool("Open", true);
            sfxManager.DoorSound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isPlayerInRange = true;
            doorMark.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isPlayerInRange = false;
            doorMark.SetActive(false);
        }
    }

}*/

{

    Animator anim;
    [SerializeField] private GameObject doorMark;
    [SerializeField] private GameObject doorMinimapIcon;
    private SFXManager sfxManager;

    private bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorMark.SetActive(true);
        }

        if (other.CompareTag("Ruhe"))
        {
            doorMark.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Submit"))
        {
            if (!isOpened)
            {
                anim.SetBool("Open", true);
                sfxManager.DoorSound();
                isOpened = true;
                doorMark.SetActive(false);
                doorMinimapIcon.SetActive(false);
            }
            
        }

        if (other.CompareTag("Ruhe") && Input.GetButtonDown("Submit"))
        {
            if (!isOpened)
            {
                anim.SetBool("Open", true);
                sfxManager.DoorSound();
                isOpened = true;
                doorMark.SetActive(false);
                doorMinimapIcon.SetActive(false);
            }
            
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!isOpened)
            {
                anim.SetBool("Open", true);
                sfxManager.DoorSound();
                isOpened = true;
                doorMark.SetActive(false);
                doorMinimapIcon.SetActive(false);
            }
        }

        if (other.CompareTag("Ruhe") && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!isOpened)
            {
                anim.SetBool("Open", true);
                sfxManager.DoorSound();
                isOpened = true;
                doorMark.SetActive(false);
                doorMinimapIcon.SetActive(false);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorMark.SetActive(false);
        }

         if (other.CompareTag("Ruhe"))
        {
            doorMark.SetActive(false);
        }
    }

}

