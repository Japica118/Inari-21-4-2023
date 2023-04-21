using UnityEngine;

public class Crystallight : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject light1;
    public GameObject light2;
    private SFXManager sfxManager;

    private bool hasActivated = false;

    private void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasActivated)
        {
            sfxManager.FireSound();
            object1.SetActive(true);
            object2.SetActive(true);
            hasActivated = true;
            light1.SetActive(true);
            light2.SetActive(true);
            enabled = false;
        }
    }
}

