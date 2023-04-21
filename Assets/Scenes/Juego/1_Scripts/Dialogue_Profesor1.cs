using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Dialogue_Profesor1 : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isTalking;
    private int lineIndex;
    GameObject target;
    GameObject npc;
    private Quaternion originalYRotation;
    public GameObject cinematica;
    private float timeElapsed = 0f;

    Animator anim;
    Animator anim2;
    Player player;

    private float typingTime = 0.01f;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private GameObject RawImage;
    private SFXManager sfxManager;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    [SerializeField] private GameObject npc1; // Assign in inspector
    [SerializeField] private GameObject npc2; // Assign in inspector

    void Awake()
    {
        anim = npc1.GetComponent<Animator>();
        anim2 = npc2.GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    void Start()
    {
        StartDialogue();
    }


    private void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                StopAllCoroutines();
                StartCoroutine(NextDialogueLineWithDelay()); // Call the modified method
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                StopAllCoroutines();
                StartCoroutine(NextDialogueLineWithDelay()); // Call the modified method
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
        lineIndex = 0;

        StartCoroutine(ShowLine());
        target = GameObject.Find("Front");
        npc = GameObject.Find("Profesor");
        originalYRotation = npc.transform.rotation;
        Debug.Log("Rotation NPC: " + originalYRotation);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        npc.transform.LookAt(targetPosition);
        player.isplayerTalking = true;
    }


    private IEnumerator NextDialogueLineWithDelay()
    {
        // Hide the dialogue box and text
        dialoguePanel.SetActive(false);
        RawImage.SetActive(false);
        dialogueText.text = string.Empty;

        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            // Show the dialogue box and text
            dialoguePanel.SetActive(true);
            backgroundImage.SetActive(true);
            RawImage.SetActive(true);
            SetIdleAnimations();
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            backgroundImage.SetActive(false);
            RawImage.SetActive(false);
            anim.SetBool("isTalking", false);
            anim2.SetBool("isTalking", false);
            npc = GameObject.Find("Profesor");

            npc.transform.SetPositionAndRotation(new Vector3(npc.transform.position.x, npc.transform.position.y, npc.transform.position.z), originalYRotation);
            player.isplayerTalking = false;
        }

        if (lineIndex >= dialogueLines.Length)
        {
            cinematica.gameObject.SetActive(true);
            Invoke("AfterCinematic", 12.0f);
        }
    }

    void AfterCinematic()
    {
        Debug.Log("AFTER WAITING");
        SceneManager.LoadScene("Scene_2");
    }




    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        // switch the animation for the two NPCs
        if (lineIndex % 2 == 0)
        {
            anim.SetBool("isTalking", true);
            anim2.SetBool("isTalking", false);
        }
        else
        {
            anim.SetBool("isTalking", false);
            anim2.SetBool("isTalking", true);
        }

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            sfxManager.TypingSound();

            // switch the animation for the two NPCs
            if (lineIndex % 2 == 0)
            {
                anim.SetBool("isTalking", true);
                anim2.SetBool("isTalking", false);
            }
            else
            {
                anim.SetBool("isTalking", false);
                anim2.SetBool("isTalking", true);
            }

            yield return new WaitForSecondsRealtime(typingTime);
            yield return null;
        }

        SetIdleAnimations();

    }

    void SetIdleAnimations()
    {
        anim.SetBool("isTalking", false);
        anim2.SetBool("isTalking", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            StopAllCoroutines();

            if (didDialogueStart)
            {
                dialoguePanel.SetActive(false);
                backgroundImage.SetActive(false);
                RawImage.SetActive(false);
                anim.SetBool("isTalking", false);
                anim2.SetBool("isTalking", false);
                npc = GameObject.Find("Profesor");

                npc.transform.SetPositionAndRotation(new Vector3(npc.transform.position.x, npc.transform.position.y, npc.transform.position.z), originalYRotation);
                player.isplayerTalking = false;
                didDialogueStart = false;
            }
        }
    }
}












