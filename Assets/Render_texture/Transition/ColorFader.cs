using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFader : MonoBehaviour
{
    private Color _fromColor = new Color(1f, 1f, 1f);
    private Color _toColor = new Color(0f, 0f, 0f);
    private Material _material;

    private bool _reset = false;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        _reset = true;
        _material.color = _fromColor;
    }

    public void StartColorFading()
    {
        _reset = false;
        StartCoroutine(ColorFadingCoroutine());
    }

    private IEnumerator ColorFadingCoroutine()
    {
        float t = 0f;

        while(t < 1f)
        {
            if(_reset)
            {
                t = 1f;
            }
            else
            {
                _material.color = Color.Lerp(_fromColor, _toColor, t);
                t += Time.deltaTime;
                yield return null;
            }
            
        }

        if(!_reset)

        _material.color = _toColor;
    }
}
