using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Torch : MonoBehaviour
/*{
    public int torchNumber;

    public static Torch torch;

    public GameObject fireParticles;
    public GameObject torchLight;
    [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;
    [SerializeField] private AudioClip torchSound;

    public bool istorchOn;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        torch = this;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!istorchOn)
            {
                abilityIcon.SetActive(true);
                audio.PlayOneShot(AbilityiconSound);
            }
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true && !istorchOn)
        {
            torchLight.gameObject.SetActive(true);
            fireParticles.gameObject.SetActive(true);
            abilityIcon.SetActive(false);
            istorchOn = true;
            audio.PlayOneShot(torchSound);

            for(int i = 0; i < TorchManager.Instance.torchesLit.Length; i++)
            {
                if(TorchManager.Instance.torchesLit[i] == 0)
                {
                    TorchManager.Instance.torchesLit[i] = torchNumber;
                    break;
                }
            }

            if(TorchManager.Instance.torchesLit[3] != 0)
            {
                TorchManager.Instance.CheckOrder(this);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!istorchOn)
            {
                abilityIcon.SetActive(false);
            }
        }
    }
}*/

{
    public int torchNumber;

    public static Torch torch;

    public GameObject fireParticles;
    public GameObject torchLight;
    [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;
    [SerializeField] private AudioClip torchSound;

    public bool istorchOn;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        torch = this;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!istorchOn)
            {
                abilityIcon.SetActive(true);
                audio.PlayOneShot(AbilityiconSound);
            }
        }
    }

    void OnTriggerStay(Collider collision)
{
    if (collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true && !istorchOn && enabled)
    {
        torchLight.gameObject.SetActive(true);
        fireParticles.gameObject.SetActive(true);
        abilityIcon.SetActive(false);
        istorchOn = true;
        audio.PlayOneShot(torchSound);

        for(int i = 0; i < TorchManager.Instance.torchesLit.Length; i++)
        {
            if(TorchManager.Instance.torchesLit[i] == 0)
            {
                TorchManager.Instance.torchesLit[i] = torchNumber;
                break;
            }
        }

        if(TorchManager.Instance.torchesLit[3] != 0)
        {
            TorchManager.Instance.CheckOrder(this);
        }
    }
}

    void ActivateTorchScript()
{
    enabled = true;
}

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!istorchOn)
            {
                abilityIcon.SetActive(false);
            }
        }
    }
}



