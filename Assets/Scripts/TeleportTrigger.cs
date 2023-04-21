using UnityEngine;
using System.Collections;

public class TeleportTrigger : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    [SerializeField] private GameObject abilityIcon;
    [SerializeField] private float jumpHeight = 2f; // the height of the jump
    [SerializeField] private float jumpDuration = 0.5f; // the duration of the jump animation

    private bool playerInsideCollider = false;
    private bool isJumping = false;
    private SFXManager sfxManager;

    private void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInsideCollider = true;
            Debug.Log("Player entered trigger!");
            abilityIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInsideCollider = false;
            Debug.Log("Player exited trigger!");
            abilityIcon.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInsideCollider && Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            sfxManager.JumpSound();
            StartCoroutine(JumpCoroutine());
        }

        if (playerInsideCollider && Input.GetKeyDown(KeyCode.JoystickButton1) && !isJumping)
        {
            isJumping = true;
            sfxManager.JumpSound();
            StartCoroutine(JumpCoroutine());
        }
    }

    private IEnumerator JumpCoroutine()
    {
        // calculate the initial and final positions for the jump animation
        Vector3 startPos = player.transform.position;
        Vector3 endPos = destination.position;
        endPos.y = startPos.y; // ensure that the player doesn't jump up and down

        // calculate the apex of the jump (the highest point)
        Vector3 apexPos = (startPos + endPos) / 2f;
        apexPos.y += jumpHeight;

        // play the jump animation
        player.GetComponentInChildren<Animator>().SetTrigger("Jump");

        // animate the player's position from the start to the apex of the jump
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime / jumpDuration;
            player.transform.position = Vector3.Lerp(startPos, apexPos, t * 2f);
            yield return null;
        }

        // animate the player's position from the apex to the end of the jump
        t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime / jumpDuration;
            player.transform.position = Vector3.Lerp(apexPos, endPos, t * 2f);
            yield return null;
        }

        // set the player's position to the final destination
        player.transform.position = endPos;

        // reset the jumping flag
        isJumping = false;
    }
}





