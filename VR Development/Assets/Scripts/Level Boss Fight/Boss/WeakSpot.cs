using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) //bullet layer
        {
            Debug.Log("WeakSpots Hit!");
            //TODO: inform boss that its weak spot is hit
        }
    }
}