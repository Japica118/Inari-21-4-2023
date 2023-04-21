using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioClip battleMusic;
    public AudioClip wonMusic;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void BattleSound()
    {
        _audioSource.PlayOneShot(battleMusic);
    }

    public void WonSound()
    {
        _audioSource.PlayOneShot(wonMusic);
    }
}
