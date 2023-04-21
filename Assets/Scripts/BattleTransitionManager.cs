using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleTransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private Animator anim;
    [SerializeField] private GameObject[] player;

    [SerializeField] private float transitionTime;

    private bool isBattleCanvasActivated;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            canvas.gameObject.SetActive(true);
            anim.SetBool("Transition_Activated", true);
            StartCoroutine(SceneBattle());
            SceneManager.LoadScene("Battle Scene");

        }
    }

    IEnumerator SceneBattle()
    {
        yield return new WaitForSeconds(transitionTime);
    }
}