using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangin : MonoBehaviour
{
public static Player Instance;
public Material defaultMaterial;
public Material newMaterial;
public GameObject hangin_magic;
public GameObject ruhe_magic;
public AudioClip iceConversion;

private Animator anim;
private AudioSource audio;

[SerializeField] private GameObject ruhe;
[SerializeField] private GameObject hangin;
[SerializeField] private GameObject abilityIcon;
[SerializeField] private AudioClip AbilityiconSound;

private bool isUsingDefaultMaterial = true;

void Start()
{
    Instance = GetComponent<Player>();

    anim = GetComponentInChildren<Animator>();
    
    audio = GetComponentInChildren<AudioSource>();
}

void OnTriggerEnter(Collider other)
{
    if(ruhe.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }

     if(hangin.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }
}

void OnTriggerStay(Collider other)
{
    if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.F) && (hangin.activeSelf == true))
    {
        Instance.enabled = false;

         Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();

            if (iceRenderer != null)
        {
            if (isUsingDefaultMaterial)
            {
                iceRenderer.material = newMaterial;
                abilityIcon.SetActive(false);
                anim.Play("Ability");
                isUsingDefaultMaterial = false;
                ruhe_magic.SetActive(true);
                Invoke("DeactivateRuheMagic", 2f);
                audio.PlayOneShot(iceConversion);
            } 
        }
    }
    
}

void OnTriggerExit(Collider other)
{

      if(hangin.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();
        
        abilityIcon.SetActive(false);

        isUsingDefaultMaterial = true;

        iceRenderer.material = defaultMaterial;

        //audio.PlayOneShot(waterConversion);
    }
}

void DeactivateHanginMagic()
{
    hangin_magic.SetActive(false);
}

void DeactivateRuheMagic()
{
    ruhe_magic.SetActive(false);

    Instance.enabled = true;
}

}

