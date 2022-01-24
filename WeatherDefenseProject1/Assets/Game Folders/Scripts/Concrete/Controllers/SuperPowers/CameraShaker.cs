using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    Vector3 _cameraInitialPos;
    [SerializeField] float _shakeMagnitude = 0.05f, _shakeTime = 1f;
    [SerializeField] Camera _mainCamera;

    public void ShakeIt()
    {
        _cameraInitialPos = _mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", _shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * _shakeMagnitude * 2 - _shakeMagnitude;
        float cameraShakingOffsetY = Random.value * _shakeMagnitude * 2 - _shakeMagnitude;

        Vector3 cameraIntermediatePos = _mainCamera.transform.position;
        cameraIntermediatePos.x += cameraShakingOffsetX;
        cameraIntermediatePos.y += cameraShakingOffsetY;

        _mainCamera.transform.position = cameraIntermediatePos;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        _mainCamera.transform.position = _cameraInitialPos;
    }
}
