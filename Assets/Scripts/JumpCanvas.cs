using UnityEngine;

public class JumpCanvas : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public LayerMask playerLayer;
    public GameObject objectToDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(false);
            }

            if (other.CompareTag("Player") && objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(false);
            }
        }
    }
}



