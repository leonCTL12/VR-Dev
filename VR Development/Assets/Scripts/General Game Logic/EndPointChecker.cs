using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointChecker : MonoBehaviour
{
    private LevelManager manager;
    private void Start()
    {
        manager = GetComponentInParent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Level Clear");
        }
    }
}
