using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelManager_BossFight : LevelManager_Base
{
    [SerializeField]
    private string bossPrefabName;
    [SerializeField]
    private Transform bossSpawnPoint;
    public override void SpawnPhotonObjects()
    {
        base.SpawnPhotonObjects();
    }

    public void UpdatePlayerUIWeakSpot(int index)
    {
        //handle current player only, coz partner player's level manager will handle theirs
        currentPlayer.GetComponent<Player_BossFight>().playerUI.DisableWeakSpot(index);
    }

    public override void Sender_SyncLevel()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(bossPrefabName, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
        }
    }
}
