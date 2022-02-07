using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is not used for now
public class SwitchControl : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPersonCamera;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject VRPlayer;
    [SerializeField]
    private bool forceVR;

    private void Start()
    {
        SetUp();
    }
    
    private void SetUp()
    {
        firstPersonCamera.SetActive(false);
        canvas.SetActive(false);
        VRPlayer.SetActive(false);

        //force bool for testing in oculus link
        if (forceVR) 
        {
            VRPlayer.SetActive(true);
            return;
        }

        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            firstPersonCamera.SetActive(true);
            canvas.SetActive(true);
        }
        if (SystemInfo.deviceType.ToString() == "Handheld") //It means VR
        {
            VRPlayer.SetActive(true);
        }
    }
}
