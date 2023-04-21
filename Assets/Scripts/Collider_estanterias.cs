using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Collider_estanterias : MonoBehaviour
{

    [SerializeField] private GameObject estanterias1;


    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ruhe"))
        {            
            estanterias1.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ruhe"))
        {
            estanterias1.SetActive(true);

        }
    }
}

