using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerTrigger : MonoBehaviour
{

    [SerializeField] private GameObject cinematicRuhe;
    private BGMManager bgmManager;

    private void Awake()
    {
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            cinematicRuhe.SetActive(true);
            bgmManager.StopBGM();
            Invoke("AfterCinematic", 12.0f);
        }
    }

    void AfterCinematic()
    {
        Debug.Log("AFTER WAITING");
        SceneManager.LoadScene("Scene_6");
    }
}

