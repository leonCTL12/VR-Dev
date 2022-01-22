using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonWandPowerBeam : MonoBehaviour
{
    public Vector3? targetPoint;

    private void Update()
    {
        if (targetPoint != null)
        {
            transform.LookAt((Vector3)targetPoint);
        }
    }
}
