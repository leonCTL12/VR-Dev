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
            spawnedPlayerPrefab.GetComponent<CameraController>().CameraOn();
        }
        if (SystemInfo.deviceType.ToString() == "Handheld")
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("XR Rig", transform.position, transform.rotation);
            spawnedPlayerPrefab.GetComponent<CameraController>().CameraOn();
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
