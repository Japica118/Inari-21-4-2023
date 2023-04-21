using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TorchManager : MonoBehaviour

{
    public static TorchManager Instance;

    public int[] torchesLit;
    public int[] torchesCorrectOrder;
    public GameObject monster;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject lights1;
    public GameObject lights2;
    public GameObject lights3;
    public GameObject lights4;

    private Torch[] torches;

    void Start()
    {
        Instance = this;
        torches = FindObjectsOfType<Torch>();
    }

    public void CheckOrder(Torch torch)
    {
        bool torch1 = false;
        bool torch2 = false;
        bool torch3 = false;
        bool torch4 = false;

        if (torchesCorrectOrder[0] == torchesLit[0])
        {
            torch1 = true;
        }

        if (torchesCorrectOrder[1] == torchesLit[1])
        {
            torch2 = true;
        }

        if (torchesCorrectOrder[2] == torchesLit[2])
        {
            torch3 = true;
        }

        if (torchesCorrectOrder[3] == torchesLit[3])
        {
            torch4 = true;
        }

        if (torch1 && torch2 && torch3 && torch4)
        {
            monster.SetActive(true);
        }
        else
        {
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            fire4.SetActive(false);
            lights1.SetActive(false);
            lights2.SetActive(false);
            lights3.SetActive(false);
            lights4.SetActive(false);

            Array.Clear(torchesLit, 0, torchesLit.Length);

            foreach (Torch t in torches)
            {
                t.istorchOn = false;
            }

            // Deactivate the "Torch" script for 3 seconds
            torch.enabled = false;
            Invoke("ActivateTorchScript", 1f);

            Debug.Log("Error luces");
        }
    }

    void ActivateTorchScript()
    {
        // Activate the "Torch" script again
        foreach (Torch t in torches)
        {
            t.enabled = true;
        }
    }
}






