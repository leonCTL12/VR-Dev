using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LevelManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject spawnPoint;
    private TogglePlanesManager togglePlanesManager;

    private PlayerController_Base currentPlayer;
    private GameObject spawnedPlayer;

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

    private void Start()
    {
        togglePlanesManager = TogglePlanesManager.Instance;
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
        togglePlanesManager.Initialse(); 
    }
    public void Sender_SyncLevel()
    {
        photonView.RPC("Receiver_SyncLevel", RpcTarget.Others, togglePlanesManager.redState_GetOnly);
    }

    [PunRPC]
    public void Receiver_SyncLevel(bool state)
    {
        Debug.Log("Received Syn Level, state = " + state);
        togglePlanesManager.ReceiveSync(state);
    }



    public void DisconnectionHandling()
    {
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}
