using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI; //Testing purpose
public class NetworkManager: MonoBehaviourPunCallbacks
{
    private LevelManager_Base levelManager;

    void Start()
    {
        ConnectToServer();
        levelManager = LevelManager_Base.Instance;
    }

    private void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect To Server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created Room");
        levelManager.InitialiseLevel();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room");
        LevelManager_Base.InputDeviceType device;

        switch(SystemInfo.deviceType.ToString())
        {
            case "Desktop":
                device = LevelManager_Base.InputDeviceType.PC;
                break;
            case "Handheld":
                device = LevelManager_Base.InputDeviceType.VR;
                break;
            default:
                device = LevelManager_Base.InputDeviceType.PC;
                break;

        }
        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            levelManager.SpawnPhotonObjects(device);
        }
        if (SystemInfo.deviceType.ToString() == "Handheld") //It means VR
        {
            //Reference
            //spawnedPlayer = PhotonNetwork.Instantiate("XR Rig", transform.position, transform.rotation);
            //spawnedPlayer.GetComponent<CameraController>().CameraOn();

            //TODO: Spawn VR Player Controller
        }

        if(!PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(levelManager.GetPartnerPlayerReference());
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        levelManager.DisconnectionHandling();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
        levelManager.Sender_SyncLevel();
        StartCoroutine(levelManager.GetPartnerPlayerReference());
    }
}
