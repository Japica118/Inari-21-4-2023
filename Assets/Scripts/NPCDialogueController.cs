using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    public GameObject mainCharacter1;
    public GameObject mainCharacter2;
    public GameObject dialogue1;
    public GameObject dialogue2;

    private bool isTalking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == mainCharacter1)
        {
            isTalking = true;
            dialogue1.SetActive(true);
            dialogue2.SetActive(false);
        }
        else if (other.gameObject == mainCharacter2)
        {
            isTalking = true;
            dialogue1.SetActive(false);
            dialogue2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == mainCharacter1 || other.gameObject == mainCharacter2)
        {
            isTalking = false;
            dialogue1.SetActive(false);
            dialogue2.SetActive(false);
        }
    }
}

