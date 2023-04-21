using UnityEngine;

public class CanvasControllerNext : MonoBehaviour
{
    public GameObject[] elementsToDeactivate; // Array of GameObjects to deactivate
    public GameObject[] elementsToActivate; // Array of GameObjects to activate
    public GameObject[] elementsToeliminate;

    private bool isActive = false; // Flag to track whether elements are currently active or not

    private int enterCount = 0; // Counter for Enter key press

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            enterCount++; // Increase Enter key press count

            if (enterCount >= 2) // If Enter key is pressed twice
            {
                // Deactivate elements in the elementsToEliminate array
                for (int i = 0; i < elementsToeliminate.Length; i++)
                {
                    Destroy(elementsToeliminate[i]);
                }

                enterCount = 0; // Reset Enter key press count
                isActive = false; // Reset flag to indicate that elements are no longer active
            }
            else if (!isActive) // If elements are not currently active
            {
                // Deactivate elements in the elementsToDeactivate array
                for (int i = 0; i < elementsToDeactivate.Length; i++)
                {
                    elementsToDeactivate[i].SetActive(false);
                }

                // Activate elements in the elementsToActivate array
                for (int i = 0; i < elementsToActivate.Length; i++)
                {
                    elementsToActivate[i].SetActive(true);
                }

                isActive = true; // Set flag to indicate that elements are now active
            }
            else // If elements are currently active
            {
                // Deactivate elements in the elementsToActivate array
                for (int i = 0; i < elementsToActivate.Length; i++)
                {
                    elementsToActivate[i].SetActive(false);
                }

                // Activate elements in the elementsToDeactivate array
                for (int i = 0; i < elementsToDeactivate.Length; i++)
                {
                    elementsToDeactivate[i].SetActive(true);
                }

                isActive = false; // Set flag to indicate that elements are no longer active
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            enterCount++; // Increase Enter key press count

            if (enterCount >= 2) // If Enter key is pressed twice
            {
                // Deactivate elements in the elementsToEliminate array
                for (int i = 0; i < elementsToeliminate.Length; i++)
                {
                    Destroy(elementsToeliminate[i]);
                }

                enterCount = 0; // Reset Enter key press count
                isActive = false; // Reset flag to indicate that elements are no longer active
            }
            else if (!isActive) // If elements are not currently active
            {
                // Deactivate elements in the elementsToDeactivate array
                for (int i = 0; i < elementsToDeactivate.Length; i++)
                {
                    elementsToDeactivate[i].SetActive(false);
                }

                // Activate elements in the elementsToActivate array
                for (int i = 0; i < elementsToActivate.Length; i++)
                {
                    elementsToActivate[i].SetActive(true);
                }

                isActive = true; // Set flag to indicate that elements are now active
            }
            else // If elements are currently active
            {
                // Deactivate elements in the elementsToActivate array
                for (int i = 0; i < elementsToActivate.Length; i++)
                {
                    elementsToActivate[i].SetActive(false);
                }

                // Activate elements in the elementsToDeactivate array
                for (int i = 0; i < elementsToDeactivate.Length; i++)
                {
                    elementsToDeactivate[i].SetActive(true);
                }

                isActive = false; // Set flag to indicate that elements are no longer active
            }
        }
    }

    
}




