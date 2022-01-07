using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.InputSystem;

public class LevelManager_Base : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private int level;
    [SerializeField]
    private string[] actionMapNameList;

    private PlayerController_Base currentPlayer;
    private GameObject spawnedPlayer;

    private static LevelManager_Base _instance;

    public static LevelManager_Base Instance
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

    protected virtual void Start()
    {
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
            spawnedPlayer.GetComponent<PlayerInput>().SwitchCurrentActionMap(actionMapNameList[level]);
        } 
    }

    public virtual void InitialiseLevel() //inherit
    {
    }

    public virtual void Sender_SyncLevel()
    {
    }

    public void TeleportPlayerTo(Transform destination, Transform cameraTransform)
    {
        currentPlayer.Teleport(destination, cameraTransform);
    }

    [PunRPC]
    public virtual void Receiver_SyncLevel(bool state)
    {
    }

    public void DisconnectionHandling()
    {
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}
