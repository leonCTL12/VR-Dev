using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToken : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (rigidbody.velocity.magnitude == 0)
        {
            transform.localRotation = Quaternion.identity;
        }
       
    }
}
