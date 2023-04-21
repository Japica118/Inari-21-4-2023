using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    //variable para acceder al AudioSource
    public static BGMManager Instance;

    private AudioSource _audioSource;


    void Awake()
    {
        //Asignamos la variable
        _audioSource = GetComponent <AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Reproducimos la BGM
        _audioSource.Play();
    }

    public void StartBGM()
    {
        _audioSource.Play();
    }
    //Funcion para parar la BGM
    public void StopBGM()
    {
        _audioSource.Stop();
    }
}
