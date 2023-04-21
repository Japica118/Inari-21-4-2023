using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXManager : MonoBehaviour
{
    public AudioClip selectSFX;
    public AudioClip moveSFX;
    public AudioClip actionSFX;
    public AudioClip backSFX;
    public AudioClip wonSFX;
    public AudioClip loseSFX;
    public AudioClip voiceSFX;
    public AudioClip typingSFX; 
    public AudioClip transitionSFX;
    public AudioClip bookSFX;
    public AudioClip doorSFX;
    public AudioClip waterupSFX;
    public AudioClip jumpSFX;
    public AudioClip fireSFX;


    //variable del audio source
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void SelectSound()
    {
        _audioSource.PlayOneShot(selectSFX);
    }

    public void MoveSound()
    {
        _audioSource.PlayOneShot(moveSFX);
    }

    public void ActionSound()
    {
        _audioSource.PlayOneShot(actionSFX);
    }

    public void BackSound()
    {
        _audioSource.PlayOneShot(backSFX);
    }

    public void WonSound()
    {
        _audioSource.PlayOneShot(wonSFX);
    }
    public void LoseSound()
    {
        _audioSource.PlayOneShot(loseSFX);
    }

    public void VoiceSound()
    {
        _audioSource.PlayOneShot(voiceSFX);
    }

    public void TransitionSound()
    {
        _audioSource.PlayOneShot(transitionSFX);
    }

    public void BookSound()
    {
        _audioSource.PlayOneShot(bookSFX);
    }

    public void DoorSound()
    {
        _audioSource.PlayOneShot(doorSFX);
    }

    public void TypingSound()
    {
        _audioSource.PlayOneShot(typingSFX);
        GetComponent<AudioSource>().pitch = Random.Range(1.6f, 1.8f);
    }

    public void WaterupSound()
    {
        _audioSource.PlayOneShot(waterupSFX);
    }

    public void JumpSound()
    {
        _audioSource.PlayOneShot(jumpSFX);
    }

    public void FireSound()
    {
        _audioSource.PlayOneShot(fireSFX);
    }
}


