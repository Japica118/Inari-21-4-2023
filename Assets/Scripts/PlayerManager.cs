using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour

{
[SerializeField] private GameObject lua;
[SerializeField] private GameObject ruhe;
[SerializeField] private GameObject hangin;
[SerializeField] private GameObject kalju;

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
    // Check if the active character is not moving before opening the radial menu
    if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton4) && Vector3.Distance(activeCharacter.transform.position, lastPosition) < 0.001f)
    {
        // Disable the animator component on the active character
        activeCharacter.GetComponentInChildren<Animator>().enabled = false;

        // Show the radial menu and pause the game
        radialMenu.SetActive(true);
        Time.timeScale = 0f;

        isRadialMenuOpen = true;
    }
    else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton2))
    {
        activeCharacter.GetComponentInChildren<Animator>().enabled = true;

        radialMenu.SetActive(false);

        Time.timeScale = 1f;

        isRadialMenuOpen = false;
    }

    // Call RadialMenuUpdate() method to check for character change input if the radial menu is open
    if (isRadialMenuOpen)
    {
        RadialMenuUpdate();
    }

    // Update the last position of the character
    lastPosition = activeCharacter.transform.position;
}



// Update is called once per frame for the radial menu
void RadialMenuUpdate()
{
    // Check for character change input
    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetAxisRaw("Left/Right") > 0 )
    {
        SwitchCharacter(lua);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetAxisRaw("Up/Down") > 0)
    {
        SwitchCharacter(ruhe);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetAxisRaw("Up/Down") < 0)
    {
        SwitchCharacter(hangin);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetAxisRaw("Left/Right") < 0)
    {
        SwitchCharacter(kalju);
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


