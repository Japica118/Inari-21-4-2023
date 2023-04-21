using UnityEngine;

public class ActivateZorro : MonoBehaviour
{
    public GameObject zorro1;
    private bool triggered = false;
    private int playerLayer = 0;
    public GameObject Cam;
    public GameObject otherGameObject;
    public GameObject chest;

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer && !triggered)
        {
            zorro1.SetActive(true);
            triggered = true; 
            Cam.gameObject.SetActive(true);
            Invoke("DeactivateZorro", 6f);
            
        }
    }

    private void DeactivateZorro()
    {
        Cam.gameObject.SetActive(false);
        zorro1.SetActive(false);
        otherGameObject.SetActive(true);
        chest.SetActive(true);
        Destroy(this.gameObject);
    }
}


