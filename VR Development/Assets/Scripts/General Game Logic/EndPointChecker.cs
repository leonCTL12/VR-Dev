using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointChecker : MonoBehaviour
{
    private LevelManager_Base manager;
    private void Start()
    {
        manager = GetComponentInParent<LevelManager_Base>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Level Clear");
        }
    }
}
