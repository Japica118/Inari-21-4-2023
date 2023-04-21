using UnityEngine;

public class ActivateZorro_sentado : MonoBehaviour
{
    public GameObject zorro1;
    private bool triggered = false;
    private int playerLayer = 0;
    public GameObject Cam;
    public GameObject otherGameObject;
    public GameObject chest;
    public GameObject collider1;
    public GameObject collider2;
    public GameObject collider3;

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
            Invoke("DeactivateZorro", 4f);

        }
    }

    private void DeactivateZorro()
    {
        Cam.gameObject.SetActive(false);
        zorro1.SetActive(false);
        otherGameObject.SetActive(true);
        chest.SetActive(true);
        Destroy(collider1.gameObject);
        Destroy(collider2.gameObject);
        Destroy(collider3.gameObject);
        Destroy(this.gameObject);
        
    }
}
