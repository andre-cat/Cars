using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] private Camera[] cameras;
    [SerializeField] private KeyCode keySwitcher;

    private int currentCamera;

    private void Awake()
    {
        currentCamera = 1;
    }

    private void Update()
    {
        if (Input.GetKeyUp(keySwitcher))
        {
            currentCamera++;
            SwitchCamera(cameras[(currentCamera - 1) % cameras.Length], cameras[currentCamera % cameras.Length]);
        }
    }

    private void SwitchCamera(Camera currentCamera, Camera nextCamera)
    {
        nextCamera.gameObject.SetActive(true);
        currentCamera.gameObject.SetActive(false);
    }
}
