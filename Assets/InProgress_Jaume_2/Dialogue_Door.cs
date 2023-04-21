using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue_Door : MonoBehaviour
{

    public static Dialogue Instance;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isTalking;
    private int lineIndex;
    GameObject target;
    GameObject npc;
    private Quaternion originalYRotation;

    Animator anim;
    public Player player; 
    public Player player2;
    public Player player3;
    public Player player4;
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
            
            /*else if(transform.gameObject.layer == 10)
            {

            }
            else if(transform.gameObject.layer == 10)
            {
                
            }*/
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
            
            /*else if(transform.gameObject.layer == 10)
            {

            }
            else if(transform.gameObject.layer == 10)
            {
                
            }*/
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
        npc = GameObject.Find("NPC");
        originalYRotation = npc.transform.rotation;
        Debug.Log("Rotation NPC: " + originalYRotation);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        npc.transform.LookAt(targetPosition);
        player.isplayerTalking = true;
        player2.isplayerTalking = true;
        player3.isplayerTalking = true;
        player4.isplayerTalking = true;
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
            npc = GameObject.Find("NPC");

            npc.transform.SetPositionAndRotation(new Vector3(npc.transform.position.x, npc.transform.position.y, npc.transform.position.z), originalYRotation);
            player.isplayerTalking = false;
            player2.isplayerTalking = false;
            player3.isplayerTalking = false;
            player4.isplayerTalking = false;
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
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ruhe") || collision.gameObject.CompareTag("Hangin") || collision.gameObject.CompareTag("Kalju") )
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ruhe") || collision.gameObject.CompareTag("Hangin") || collision.gameObject.CompareTag("Kalju") )
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }
    }

}

