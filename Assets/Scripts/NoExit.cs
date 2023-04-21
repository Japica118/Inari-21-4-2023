using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class NoExit : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isTalking;
    private int lineIndex;
    [SerializeField] private GameObject luaTalking;
    GameObject target;
    GameObject npc;


    Animator anim;
    Player player;

    private float typingTime = 0.01f;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private GameObject RawImage;
    private SFXManager sfxManager;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    [SerializeField] private GameObject npc1; // Assign in inspector

    void Awake()
    {
        anim = npc1.GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    void Update()
    {
        if (isPlayerInRange)
        {

            if (dialogueText.text == dialogueLines[lineIndex])
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
        backgroundImage.SetActive(true);
        RawImage.SetActive(true);
        luaTalking.SetActive(true);
        lineIndex = 0;

        StartCoroutine(ShowLine());
        target = GameObject.Find("Front");
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        npc.transform.LookAt(targetPosition);
        player.isplayerTalking = true;
    }


    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            SetIdleAnimations();
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            backgroundImage.SetActive(false);
            RawImage.SetActive(false);
            luaTalking.SetActive(false);
            anim.SetBool("isTalking", false);
            player.isplayerTalking = false;
            //Time.timeScale = 1f;
        }
    }


    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        // switch the animation for the two NPCs
        if (lineIndex % 2 == 0)
        {
            anim.SetBool("isTalking", true);
        }
        else
        {
            anim.SetBool("isTalking", false);
        }

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            sfxManager.TypingSound();

            // switch the animation for the two NPCs
            if (lineIndex % 2 == 0)
            {
                anim.SetBool("isTalking", true);
            }
            else
            {
                anim.SetBool("isTalking", false);
            }

            yield return new WaitForSecondsRealtime(typingTime);
            yield return null;
        }

        SetIdleAnimations();

    }

    void SetIdleAnimations()
    {
        anim.SetBool("isTalking", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ruhe"))
        {
            StartDialogue();
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited");
        if (other.CompareTag("Player") || other.CompareTag("Ruhe"))
        {
            isPlayerInRange = false;
            StopAllCoroutines();

            if (didDialogueStart)
            {
                dialoguePanel.SetActive(false);
                backgroundImage.SetActive(false);
                RawImage.SetActive(false);
                luaTalking.SetActive(false);
                anim.SetBool("isTalking", false);
                player.isplayerTalking = false;
            }
        }
    }
}
