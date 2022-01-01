using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject PCPlayerController;

    private GameObject spawnedPlayerPrefab;



    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();


        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Sphere", transform.position, transform.rotation);
            spawnedPlayerPrefab.GetComponent<CameraController>().CameraOn();
        }
        if (SystemInfo.deviceType.ToString() == "Handheld") //It means VR
        {
            //Reference
            //spawnedPlayerPrefab = PhotonNetwork.Instantiate("XR Rig", transform.position, transform.rotation);
            //spawnedPlayerPrefab.GetComponent<CameraController>().CameraOn();

            //TODO: Spawn VR Player Controller
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
