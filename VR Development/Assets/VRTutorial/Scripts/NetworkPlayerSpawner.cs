using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Sphere", transform.position, transform.rotation);
        }
        if (SystemInfo.deviceType.ToString() == "Handheld")
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Cube", transform.position, transform.rotation);
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
