using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject targetCamera;

    public void CameraOn()
    {
        targetCamera.SetActive(true);
    }
}
