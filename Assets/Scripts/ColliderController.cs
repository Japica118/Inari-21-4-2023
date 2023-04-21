using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
        }
    }
}

