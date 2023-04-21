using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RuheAndHanginOnFieldAbility : MonoBehaviour
/*{

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
    if (ruhe.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }

    if (hangin.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }
}

void OnTriggerStay(Collider other)
{
    if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.F) && hangin.activeSelf == true)
    {
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
                Instance.enabled = false;
            }
        }
    }

    else if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.F) && ruhe.activeSelf == true)
    {
        Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();

        if (iceRenderer != null)
        {
            if (isUsingDefaultMaterial)
            {
                iceRenderer.material = newMaterial;
                abilityIcon.SetActive(false);
                anim.Play("Ability");
                isUsingDefaultMaterial = false;
                hangin_magic.SetActive(true);
                Invoke("DeactivateHanginMagic", 2f);
                audio.PlayOneShot(iceConversion);
                Instance.enabled = false;
            }
        }
    }
}

void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Ice"))
    {
        Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();
        if (iceRenderer != null && iceRenderer.material != defaultMaterial)
        {
            iceRenderer.material = defaultMaterial;
        }
    }
    abilityIcon.SetActive(false);
    isUsingDefaultMaterial = true;
}


void DeactivateHanginMagic()
{
    hangin_magic.SetActive(false);

    // Enable movement script or control script
    Instance.enabled = true;
}

void DeactivateRuheMagic()
{
    ruhe_magic.SetActive(false);

    Instance.enabled = true;
}

}*/

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
    if (ruhe.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }

    if (hangin.activeSelf == true && other.gameObject.CompareTag("Ice"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }
}

void OnTriggerStay(Collider other)
{
    bool inputReceived = false;

    if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.JoystickButton0) && hangin.activeSelf == true)
    {
           inputReceived = true;
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
                Instance.enabled = false;
            }
        }
    }


    else if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.JoystickButton0) && ruhe.activeSelf == true)
    {
        inputReceived = true;
        Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();
         

        if (iceRenderer != null)
        {
            if (isUsingDefaultMaterial)
            {
                iceRenderer.material = newMaterial;
                abilityIcon.SetActive(false);
                anim.Play("Ability");
                isUsingDefaultMaterial = false;
                hangin_magic.SetActive(true);
                Invoke("DeactivateHanginMagic", 2f);
                audio.PlayOneShot(iceConversion);
                Instance.enabled = false;
            }
        }
    }


    if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.F) && hangin.activeSelf == true)
    {
         inputReceived = true;
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
                Instance.enabled = false;
            }
        }
    }

    else if (other.gameObject.CompareTag("Ice") && Input.GetKeyDown(KeyCode.F) && ruhe.activeSelf == true)
    {
         inputReceived = true;
        Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();

        if (iceRenderer != null)
        {
            if (isUsingDefaultMaterial)
            {
                iceRenderer.material = newMaterial;
                abilityIcon.SetActive(false);
                anim.Play("Ability");
                isUsingDefaultMaterial = false;
                hangin_magic.SetActive(true);
                Invoke("DeactivateHanginMagic", 2f);
                audio.PlayOneShot(iceConversion);
                Instance.enabled = false;
            }
        }
    }
}

void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Ice"))
    {
        Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();
        if (iceRenderer != null && iceRenderer.material != defaultMaterial)
        {
            iceRenderer.material = defaultMaterial;
        }
    }
    
    abilityIcon.SetActive(false);
    isUsingDefaultMaterial = true;
}


void DeactivateHanginMagic()
{
    hangin_magic.SetActive(false);

    // Enable movement script or control script
    Instance.enabled = true;
}

void DeactivateRuheMagic()
{
    ruhe_magic.SetActive(false);

    Instance.enabled = true;
}

}


