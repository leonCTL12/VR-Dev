using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LevelManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject spawnPoint;

    private PlayerController_Base currentPlayer;
    private GameObject spawnedPlayer;
    private GameObject togglePlanes;

    private static LevelManager _instance;

    public static LevelManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    public void DeathHandling()
    {
        currentPlayer.DeathHandler(spawnPoint.transform);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created Room");
        InitialiseLevel();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            Vector3 randomOffset = new Vector3(Random.Range(0,5), 0, Random.Range(0, 5));
            //add a random offset to prevent two player's collider clash and stick together
            spawnedPlayer = PhotonNetwork.Instantiate("PC First Person Player (Base)", spawnPoint.transform.position+randomOffset, spawnPoint.transform.rotation);
            //spawnedPlayer.transform.parent = playersContainer.transform;
            currentPlayer = spawnedPlayer.GetComponent<PlayerController_Base>();
        }
        if (SystemInfo.deviceType.ToString() == "Handheld") //It means VR
        {
            //Reference
            //spawnedPlayer = PhotonNetwork.Instantiate("XR Rig", transform.position, transform.rotation);
            //spawnedPlayer.GetComponent<CameraController>().CameraOn();

            //TODO: Spawn VR Player Controller
        }
    }

    private void InitialiseLevel()
    {
        togglePlanes = PhotonNetwork.Instantiate("Toggle Planes", Vector3.zero, Quaternion.identity);
        togglePlanes.transform.localScale = new Vector3(5, 5, 5); //Hardcode value to suit the size of VR player
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayer);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public void TogglePlane(bool redState)
    {
        foreach (Transform child in GameObject.Find("Toggle Planes(Clone)").transform)
        {
            child.GetComponent<TogglePlane>().Toggle(redState);
        }
    }
}
