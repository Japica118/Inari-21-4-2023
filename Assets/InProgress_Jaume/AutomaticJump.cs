using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticJump : MonoBehaviour

{
    public Transform teleportLocation;
    public KeyCode activationKey = KeyCode.Space;
    private Animator anim;
    public string animationTrigger = "Teleport";

    [SerializeField] private GameObject abilityIcon;



    private bool canTeleport = false;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeleportTrigger"))
        {
            canTeleport = true;
            abilityIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TeleportTrigger"))
        {
            canTeleport = false;
            abilityIcon.SetActive(false);
        }
    }

    private void Update()
    {
        if (canTeleport && Input.GetKeyDown(activationKey))
        {
            anim.SetTrigger(animationTrigger);
            Invoke("PlayerTeleport", 1f); 
        }
    }

    private void PlayerTeleport()
    {
        transform.position = teleportLocation.position;
        transform.rotation = teleportLocation.rotation;
    }
}
