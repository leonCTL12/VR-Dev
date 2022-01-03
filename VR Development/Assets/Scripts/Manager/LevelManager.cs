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

    public enum InputDeviceType
    {
        PC, VR, mobile
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

    public void SpawnPlayer(InputDeviceType InputDeviceType)
    {
        if (InputDeviceType == InputDeviceType.PC)
        {
            Vector3 randomOffset = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            //add a random offset to prevent two player's collider clash and stick together
            spawnedPlayer = PhotonNetwork.Instantiate("PC First Person Player (Base)", spawnPoint.transform.position + randomOffset, spawnPoint.transform.rotation);
            //spawnedPlayer.transform.parent = playersContainer.transform;
            currentPlayer = spawnedPlayer.GetComponent<PlayerController_Base>();
        } 
    }

    public void InitialiseLevel()
    {
        togglePlanes = PhotonNetwork.Instantiate("Toggle Planes", Vector3.zero, Quaternion.identity);
        togglePlanes.transform.localScale = new Vector3(5, 5, 5); //Hardcode value to suit the size of VR player
        TogglePlane(true); 
    }

    public void DisconnectionHandling()
    {
        PhotonNetwork.Destroy(spawnedPlayer);
    }

    

    [PunRPC]
    public void TogglePlane(bool redState)
    {
        Debug.Log("In Level Manager Toggle Plane");
        Debug.Log("Cant find it: " + (GameObject.Find("Toggle Planes(Clone)") == null));
        foreach (Transform child in GameObject.Find("Toggle Planes(Clone)").transform)
        {
            child.GetComponent<TogglePlane>().Toggle(redState);
        }
    }
}
