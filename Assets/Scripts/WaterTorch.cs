using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTorch : MonoBehaviour
{
    public GameObject fireParticles;
    public GameObject torchLight;
    [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;
    [SerializeField] private AudioClip torchSound;


    public bool isTorchOn;
    public GameObject waterObject;
    public float waterRiseHeight;
    public float waterRiseTime;
    private float currentWaterLevel;
    public GameObject Cam;
    private SFXManager sfxManager;
    private float timer;
    



    private AudioSource audio;
    private Vector3 waterStartPosition;
    private Vector3 waterEndPosition;
    private bool isWaterRising;
    private float waterRiseStartTime;
    private Vector3 waterCurrentPosition;

    private static int torchCount = 0; // Keep track of the number of lit torches

    private void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        waterStartPosition = waterObject.transform.position;
        waterEndPosition = new Vector3(waterStartPosition.x, waterStartPosition.y + currentWaterLevel, waterStartPosition.z);
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isTorchOn)
            {
                abilityIcon.SetActive(true);
                audio.PlayOneShot(AbilityiconSound);
            }
        }

        if (collision.gameObject.CompareTag("Player") && isTorchOn == false && LuaOnFieldAbility.Instance.fire == true)
        {
            sfxManager.WaterupSound();
            Cam.gameObject.SetActive(true);
            timer = 0f;
            audio.PlayOneShot(torchSound);
            abilityIcon.SetActive(false);
            torchLight.gameObject.SetActive(true);
            fireParticles.gameObject.SetActive(true);
            isTorchOn = true;
            currentWaterLevel += waterRiseHeight;
            torchCount++;
            waterStartPosition = waterObject.transform.position;
            waterEndPosition = new Vector3(waterStartPosition.x, waterStartPosition.y + currentWaterLevel, waterStartPosition.z);
            StartWaterRise();
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true && isTorchOn == false)
        {
            sfxManager.WaterupSound();
            Cam.gameObject.SetActive(true);
            torchLight.gameObject.SetActive(true);
            fireParticles.gameObject.SetActive(true);
            abilityIcon.SetActive(false);
            isTorchOn = true;
            currentWaterLevel += waterRiseHeight;
            torchCount++;
            waterStartPosition = waterObject.transform.position;
            waterEndPosition = new Vector3(waterStartPosition.x, waterStartPosition.y + currentWaterLevel, waterStartPosition.z);
            StartWaterRise();
            audio.PlayOneShot(torchSound);
        }
    }


    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isTorchOn)
            {
                abilityIcon.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isWaterRising)
        {
            float timeElapsed = Time.time - waterRiseStartTime;
            float progress = timeElapsed / waterRiseTime;
            if (progress >= 1f)
            {
                isWaterRising = false;
                waterObject.transform.position = waterEndPosition;
                Cam.gameObject.SetActive(false);

            }
            else
            {
                Vector3 newPosition = Vector3.Lerp(waterStartPosition, waterEndPosition, progress);
                waterObject.transform.position = newPosition;
            }
        }

    }


    void StartWaterRise()
    {
        isWaterRising = true;
        waterRiseStartTime = Time.time;
    }
}





