using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvrosDisplay : MonoBehaviour
{
    public AvrosManager avrosManager;
    private Text avrosText;

    // Start is called before the first frame update
    void Start()
    {
        avrosManager = FindObjectOfType<AvrosManager>();
        avrosText = GetComponent<Text>();
    }

    void Update()
{
    avrosText.text = avrosManager.GetAvros().ToString();
}
}