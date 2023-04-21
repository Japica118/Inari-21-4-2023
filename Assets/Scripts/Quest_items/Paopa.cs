using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paopa : MonoBehaviour
{

    //private SFXManager sfxManager;
    private int paopa;
    // Start is called before the first frame update
    void Awake()
    {
        //sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            paopa++;
            Debug.Log("Paopa fruit added");
            Destroy(this.gameObject);
            //sfxManager.CoinSound();
        }

        /*if(paopa==1 && )
        {
            Debug.Log("Has cumplido la mision");
        }*/

    }
}