using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    private LevelManager manager;

    private void Start()
    {
        manager = GetComponentInParent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You Died");
            manager.DeathHandling();
        }
    }
}
