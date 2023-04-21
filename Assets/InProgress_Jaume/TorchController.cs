using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public GameObject fireParticles;
    public GameObject secondfireParticles;
    public GameObject torchLight;
    public GameObject secondTorchLight;
    public Animator doorAnimator;
    //private AudioSource audio;

    private void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (fireParticles.activeSelf && secondfireParticles.activeSelf && torchLight.activeSelf && secondTorchLight.activeSelf)
        {
            doorAnimator.SetBool("Open", true);
        }
    }
}



