using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public GameObject damageText;
    public Text dmgText;

    public void Start()
    {
        
    }

    public void SetDamageGraphicPosition(CharacterControl charControl, string damage)
    {
        if (charControl == null)
            return;
        Vector3 targetPosition = new Vector3(charControl.transform.position.x, charControl.transform.position.y, charControl.transform.position.z);
        damageText.transform.position = targetPosition;
        damageText.transform.LookAt(2 * damageText.transform.position - Camera.main.transform.position);
        dmgText.text = damage;
        damageText.SetActive(true);

        //cursorAnimator.Play("Cursor");
    }

    public void RemoveDamageGraphicPosition()
    {
        Destroy(damageText);
    }
}
