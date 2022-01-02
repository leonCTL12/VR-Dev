using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LevelManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject spawnPoint;
    private GameObject playersContainer;

    private PlayerController_Base currentPlayer;
    private GameObject spawnedPlayerPrefab;

    public void DeathHandling()
    {
        currentPlayer.DeathHandler(spawnPoint.transform);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        //playersContainer = GameObject.Find("PlayersContainer(Clone)");

        //if (playersContainer == null)
        //{
        //    playersContainer = PhotonNetwork.Instantiate("PlayersContainer",new Vector3(0,0,0), Quaternion.identity);
        //}

        //DisableOtherPlayerControll();

        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            Vector3 randomOffset = new Vector3(Random.Range(0,5), 0, Random.Range(0, 5));
            //add a random offset to prevent two player's collider clash and stick together
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("PC First Person Player (Base)", spawnPoint.transform.position+randomOffset, spawnPoint.transform.rotation);
            //spawnedPlayerPrefab.transform.parent = playersContainer.transform;
            currentPlayer = spawnedPlayerPrefab.GetComponent<PlayerController_Base>();
        }
        if (SystemInfo.deviceType.ToString() == "Handheld") //It means VR
        {
            //Reference
            //spawnedPlayerPrefab = PhotonNetwork.Instantiate("XR Rig", transform.position, transform.rotation);
            //spawnedPlayerPrefab.GetComponent<CameraController>().CameraOn();

            //TODO: Spawn VR Player Controller
        }
    }

    private void DisableOtherPlayerControll()
    {
        foreach (Transform child in playersContainer.transform)
        {
            //if (!child.gameObject.GetComponent<PlayerController_Base>().self)
            //{
            //    child.gameObject.SetActive(false);
            //}
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
        //DisableOtherPlayerControll();
    }
}
