using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Final_game : MonoBehaviour
{

    private BGMManager bgmManager;
    [SerializeField] private GameObject cinematicAnimatica;

    private void Awake()
    {
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bgmManager.StopBGM();
            cinematicAnimatica.SetActive(true);
            Invoke("AfterCinematic", 92.0f);
        }
    }

    void AfterCinematic()
    {
        Debug.Log("AFTER WAITING");
        SceneManager.LoadScene("Main_Menu");
    }

}
