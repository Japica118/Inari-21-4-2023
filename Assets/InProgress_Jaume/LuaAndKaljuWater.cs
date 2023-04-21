using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaAndKaljuWater : MonoBehaviour
{

    void Start()
    {

    }
    
    public Material defaultMaterial;

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Ice"))
        {
            Renderer iceRenderer = collider.gameObject.GetComponent<Renderer>();
        
            iceRenderer.material = defaultMaterial;

            //audio.PlayOneShot(waterConversion);
        }
    }
}
