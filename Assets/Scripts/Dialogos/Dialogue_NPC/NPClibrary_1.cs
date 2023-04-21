using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NPClibrary_1 : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isTalking;
    private int lineIndex;
    GameObject target;
    GameObject npc;

    Animator anim;
    public Player player; 
    public Player player2;

    private float typingTime = 0.05f;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();

    }


    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            if(!didDialogueStart)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();

                dialogueText.text = dialogueLines[lineIndex];
            }
            
        }

        if(isPlayerInRange && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if(!didDialogueStart)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();

                dialogueText.text = dialogueLines[lineIndex];
            }
            
        }
        
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        anim.SetBool("isTalking", true);
        
        StartCoroutine(ShowLine());
        target = GameObject.Find("Front");
        dialogueMark.SetActive(false);
        player.isplayerTalking = true;
        player2.isplayerTalking = true;
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            anim.SetBool("isTalking", false);
            player.isplayerTalking = false;
            player2.isplayerTalking = false;
            //Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;

            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter(Collider collision )
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ruhe"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ruhe"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }
    }

}

