using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredScreen : MonoBehaviour
{
    public GameObject[] _pieces;
    public GameObject _explosionObject;
    public ColorFader _backgroundColorFader;

    private Vector3[] _piecesStartPosition;
    private Quaternion[] _piecesStartRotation;

    private float _explosionForce = 1000f;
    private Vector3 _explosionPosition;
    private float _explosionRadius = 2.5f;

    private float _minTorque = 100f;
    private float _maxTorque = 5000f;
    private bool _reset = false;
    // Start is called before the first frame update
    void Start()
    {
        Shatter();
        _explosionPosition = _explosionObject.transform.position;
        _piecesStartPosition = new Vector3[_pieces.Length];
        _piecesStartRotation = new Quaternion[_pieces.Length];

        for (int i = 0; i < _pieces.Length; i++)
        {
            _piecesStartPosition[i]= _pieces[i].transform.position;
            _piecesStartRotation[i] = _pieces[i].transform.rotation;
        }
    }

    public void Shatter()
    {
        _reset = false;
        //StartCoroutine(ShatterCoroutine());
        StartCoroutine(ShatterWithExplosionForceCoroutine());
    }
    public void Reset()
    {
        _reset = true;
        for (int i = 0; i < _pieces.Length; i++)
        {
            Rigidbody rb = _pieces[i].GetComponent<Rigidbody>();
            rb.Sleep();
            _pieces[i].transform.position = _piecesStartPosition[i];
            _pieces[i].transform.rotation = _piecesStartRotation[i];
            rb.useGravity = false;
            //_pieces[i].SetActive(true);
        }

        _backgroundColorFader.Reset();
    }

    private IEnumerator ShatterWithExplosionForceCoroutine()
    {

        if(!_reset)
        {
            for (int i = 0; i < _pieces.Length; i++)
            {
                _pieces[i].transform.Rotate(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
            }

            yield return new WaitForSeconds(1f);

            //yield return null;
            for (int i = 0; i < _pieces.Length; i++)
            {
                float torque_x = Random.Range(_minTorque, _maxTorque);
                float torque_y = Random.Range(_minTorque, _maxTorque);
                float torque_z = Random.Range(_minTorque, _maxTorque);
                Rigidbody rb = _pieces[i].GetComponent<Rigidbody>();
                rb.AddExplosionForce(_explosionForce, _explosionPosition, _explosionRadius);
                rb.AddTorque(new Vector3(torque_x, torque_y, torque_z));
                rb.useGravity = true;
            }

            _backgroundColorFader.StartColorFading();
        }

        yield return null;

        
    }

    // Update is called once per frame
    private IEnumerator ShatterCoroutine()
    {
        
        for(int i = 0; i < _pieces.Length; i++)
        {
            if(_reset)
            {
                i = _pieces.Length;
            }
            else
            {
                _pieces[i].SetActive(false);
                yield return new WaitForSeconds(0.005f);
            }
            
        }
    }
}
