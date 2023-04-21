using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    private TouchScreenKeyboard _keyboard;

    public GameObject _sceneCamera;
    public GameObject _sceneCameraCaptureCamera;
    public GameObject _shatteredScreenCamera;
    public ShatteredScreen _shatteredScreen;

    public void Awake()
    {
        _sceneCamera.SetActive(true);
        _sceneCameraCaptureCamera.SetActive(false);
        _shatteredScreenCamera.SetActive(false);
    }

    void Start()
    {

    }

    public void EndDialogue()
    {
        ShatterScreenCoroutine();
    }

    private void ShatterScreen()
    {
        ShatterScreenCoroutine();
    }

    private void ResetScreen()
    {
        _sceneCamera.SetActive(true);
        _shatteredScreen.Reset();
        _sceneCameraCaptureCamera.SetActive(false);
        _shatteredScreenCamera.SetActive(false);
    }

    private IEnumerator ShatterScreenCoroutine()
    {
        _sceneCameraCaptureCamera.SetActive(true);
        yield return null;
        _sceneCamera.SetActive(false);
        _sceneCameraCaptureCamera.SetActive(false);

        _shatteredScreenCamera.SetActive(true);
        _shatteredScreen.Shatter();
    }
}

