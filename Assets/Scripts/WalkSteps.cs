using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSteps : MonoBehaviour
{

    private AudioSource audio;
    public AudioClip Ground, Carpet, Tatami, Ice, Dirt;
    public LayerMask groundLayer, carpetLayer, tatamiLayer, iceLayer, dirtLayer;
    public Transform checkPoint;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    void SoundWalk()
    {
        if(Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, groundLayer))
        {
            audio.PlayOneShot(Ground);
            audio.volume = Random.Range(0.3f, 1f);
        }
        if (Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, carpetLayer))
        {
            audio.PlayOneShot(Carpet);
            audio.volume = Random.Range(0.3f, 1f);
        }
        if (Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, tatamiLayer))
        {
            audio.PlayOneShot(Tatami);
            audio.volume = Random.Range(0.3f, 1f);
        }

        if (Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, iceLayer))
        {
            audio.PlayOneShot(Ice);
            audio.volume = Random.Range(0.3f, 1f);
        }

         if (Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, dirtLayer))
        {
            audio.PlayOneShot(Dirt);
            audio.volume = Random.Range(0.3f, 1f);
        }


    }


}