using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointChecker : MonoBehaviour
{
    private LevelManager_Base manager;

    private void Start()
    {
        manager = LevelManager_Base.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            manager.EndGameSignalReceiver(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.EndGameSignalReceiver(false);

        }
    }


}
