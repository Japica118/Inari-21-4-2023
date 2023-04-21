using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager_3players : MonoBehaviour
{
    [SerializeField] private GameObject lua;
    [SerializeField] private GameObject ruhe;
    [SerializeField] private GameObject hangin;

    private GameObject activeCharacter;
    private Vector3 lastPosition;

    [SerializeField] private GameObject radialMenu;

    private bool isRadialMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        activeCharacter = lua;
        lastPosition = lua.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && Vector3.Distance(activeCharacter.transform.position, lastPosition) < 0.001f)
        {
            // Disable the animator component on the active character
            activeCharacter.GetComponentInChildren<Animator>().enabled = false;

            // Show the radial menu and pause the game
            radialMenu.SetActive(true);
            Time.timeScale = 0f;

             isRadialMenuOpen = true;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4) && Vector3.Distance(activeCharacter.transform.position, lastPosition) < 0.001f)
        {
            // Disable the animator component on the active character
            activeCharacter.GetComponentInChildren<Animator>().enabled = false;

            // Show the radial menu and pause the game
            radialMenu.SetActive(true);
            Time.timeScale = 0f;

             isRadialMenuOpen = true;
        }

        else if(Input.GetKeyDown(KeyCode.Escape))
        {
             activeCharacter.GetComponentInChildren<Animator>().enabled = true;

            radialMenu.SetActive(false);

            Time.timeScale = 1f;

            isRadialMenuOpen = false;
        }

        else if(Input.GetKeyDown(KeyCode.JoystickButton2))
        {
             activeCharacter.GetComponentInChildren<Animator>().enabled = true;

            radialMenu.SetActive(false);

            Time.timeScale = 1f;

            isRadialMenuOpen = false;
        }

        if (isRadialMenuOpen)
    {
        RadialMenuUpdate();
    }

    // Update the last position of the character
    lastPosition = activeCharacter.transform.position;

}

    void RadialMenuUpdate()
{
    // Check for character change input
    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetAxisRaw("Left/Right") > 0 )
    {
        SwitchCharacter(lua);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetAxisRaw("Up/Down") > 0)
    {
        SwitchCharacter(ruhe);
    }

    else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetAxisRaw("Up/Down") < 0)
    {
        SwitchCharacter(hangin);
    }
}

    private void SwitchCharacter(GameObject newCharacter)
{
    lastPosition = activeCharacter.transform.position;
    newCharacter.transform.position = lastPosition;

    activeCharacter.SetActive(false);
    newCharacter.SetActive(true);

    activeCharacter = newCharacter;
    activeCharacter.GetComponentInChildren<Animator>().enabled = true;

    radialMenu.SetActive(false);
    Time.timeScale = 1f;

    isRadialMenuOpen = false;
}

}


