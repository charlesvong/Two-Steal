using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ThirdPersonCameraController : MonoBehaviour
{
    [FormerlySerializedAs("RotationSpeed")] public float rotationSpeed = 1;
    [FormerlySerializedAs("CamCenter")] public Transform camCenter;
    [FormerlySerializedAs("Player")] public Transform player;
    private float _mouseX, _mouseY;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    private void CamControl()
    {
        _mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        _mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        _mouseY = Mathf.Clamp(_mouseY, -35, 60);
        
        transform.LookAt(camCenter);

        camCenter.rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
        player.rotation = Quaternion.Euler(0, _mouseX, 0);
    }
}
