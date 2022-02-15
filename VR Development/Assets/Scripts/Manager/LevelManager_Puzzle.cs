using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_Puzzle : LevelManager_Base
{
    public void TeleportPlayerTo(Transform destination, Transform cameraTransform)
    {
        currentPlayer.GetComponent<Player_Puzzle>().Teleport(destination, cameraTransform);
    }

    //unused, maybe remove later
    public void DeathHandling(bool isPartnerPlayer) 
    {
        if (isPartnerPlayer)
        {
            //Do Nothing for now, coz photon transform view auto sync player's position
        }
        else
        {
            currentPlayer.GetComponent<Player_Puzzle>().DeathHandler(spawnPoint.transform);
        }
    }
}
