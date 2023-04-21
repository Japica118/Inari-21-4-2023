using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private bool isPauseMenuOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if (isPauseMenuOpen)
            {
                // Resume game
                canvas.SetActive(false);
                Time.timeScale = 1f;
                isPauseMenuOpen = false;
            }
            else
            {
                // Pause game
                canvas.SetActive(true);
                Time.timeScale = 0f;
                isPauseMenuOpen = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (isPauseMenuOpen)
            {
                // Close pause menu
                canvas.SetActive(false);
                Time.timeScale = 1f;
                isPauseMenuOpen = false;
            }
        }
    }
}