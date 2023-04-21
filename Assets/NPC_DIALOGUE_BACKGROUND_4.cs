using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPC_DIALOGUE_BACKGROUND_4 : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isTalking;
    private int lineIndex;
    GameObject target;
    [SerializeField] private GameObject npc;
    private Quaternion originalYRotation;

    Animator anim;
    public Player player;
    public Player player2;

    AI_NPCs_Random ai;

    AI_NPCs ai_v2;

    private float typingTime = 0.05f;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
        ai = GetComponent<AI_NPCs_Random>();
        ai_v2 = GetComponent<AI_NPCs>();
        StartDialogue();
    }


    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
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
        originalYRotation = npc.transform.rotation;
        Debug.Log("Rotation NPC: " + originalYRotation);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        dialogueMark.SetActive(false);

        npc.transform.LookAt(targetPosition);
        player.isplayerTalking = true;
        player2.isplayerTalking = true;
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            anim.SetBool("isTalking", false);

            npc.transform.SetPositionAndRotation(new Vector3(npc.transform.position.x, npc.transform.position.y, npc.transform.position.z), originalYRotation);
            player.isplayerTalking = false;
            SceneManager.LoadScene("Main_Menu");
            player2.isplayerTalking = false;

            ai.currentState = AI_NPCs_Random.State.Travelling;

            ai_v2.currentState = AI_NPCs.State.Patrolling;
            
        }
    }


    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;

            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }

        if (collision.gameObject.CompareTag("Ruhe"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }

        if (collision.gameObject.CompareTag("Hangin"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }

        if (collision.gameObject.CompareTag("Kalju"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }

        if (collision.gameObject.CompareTag("Ruhe"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }

        if (collision.gameObject.CompareTag("Hangin"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }

        if (collision.gameObject.CompareTag("Kalju"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }
    }
}

