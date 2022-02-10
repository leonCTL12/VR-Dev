using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    private LevelManager_Puzzle manager;

    private void Start()
    {
        manager = GetComponentInParent<LevelManager_Puzzle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.DeathHandling(!other.GetComponent<PlayerController_Base>().isMine);
        }
    }
}
