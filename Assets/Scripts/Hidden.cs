using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    [SerializeField] public GameObject hiddenObject;


    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true)
        {
            hiddenObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player") || LuaOnFieldAbility.Instance.fire == false)
        {
            hiddenObject.SetActive(false);
        }
    }
}
