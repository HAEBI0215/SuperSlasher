using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{
    PlayerMove playerMove;
    CinemachineFreeLook freeLook;   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        freeLook = GetComponent<CinemachineFreeLook>();
        playerMove = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }
}
