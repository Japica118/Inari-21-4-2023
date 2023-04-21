using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KaljuOnFieldAbility : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;

    [SerializeField] private GameObject kalju;
     [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;
    [SerializeField] private AudioClip rockSound;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        audio = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
{
    if(collider.gameObject.CompareTag("Rock"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }
}

    void OnTriggerStay(Collider collider)
{
    if (collider.gameObject.CompareTag("Rock") && Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton0) && (kalju.activeSelf == true))
    {
        anim.SetTrigger("Kalju_ability");

        abilityIcon.SetActive(false);
        
        Invoke("ActivateRockSound", 1f);
    }
}

void OnTriggerExit(Collider collider)
{
    if(collider.gameObject.CompareTag("Rock"))
    {
        abilityIcon.SetActive(false);
    }
}

void ActivateRockSound()
{
    audio.PlayOneShot(rockSound);
}

}