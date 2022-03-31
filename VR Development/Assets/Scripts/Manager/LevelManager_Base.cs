using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.InputSystem;

public class LevelManager_Base : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public GameObject spawnPoint;

    [SerializeField]
    private int level;
    [SerializeField]
    private string[] actionMapNameList;
    [SerializeField]
    private string PCPlayerPrefabName;
    [SerializeField]
    private string VRPlayerPrefabName;
    [SerializeField]
    private GameObject mobileCanvasPrefab;

    #region Temp Param
    [SerializeField]
    private bool dontSpawnObject;
    #endregion

    public GameObject currentPlayer;
    public GameObject partnerPlayer;
    private GameObject spawnedPlayer;

    private PlatformSetter platformSetter;

    private static LevelManager_Base _instance;

    public static LevelManager_Base Instance
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

    protected virtual void Start()
    {
        platformSetter = PlatformSetter.Instance;
    }

    public virtual void SpawnPhotonObjects()
    {
        #region Temp Code
        if (dontSpawnObject) { return; }
        #endregion

        if (platformSetter.platform == PlatformSetter.Platforms.mobile)
        {
            Vector3 randomOffset = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            //add a random offset to prevent two player's collider clash and stick together
            spawnedPlayer = PhotonNetwork.Instantiate(PCPlayerPrefabName, spawnPoint.transform.position + randomOffset, spawnPoint.transform.rotation);
            //spawnedPlayer.transform.parent = playersContainer.transform;
            currentPlayer = spawnedPlayer;
            GameObject mobileCanvas = GameObject.Instantiate(mobileCanvasPrefab);
            mobileCanvas.transform.parent = spawnedPlayer.transform;
            spawnedPlayer.GetComponent<PlayerInput>().SwitchCurrentActionMap(actionMapNameList[level]);
        }
        else if (platformSetter.platform == PlatformSetter.Platforms.pc)
        {
            Vector3 randomOffset = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
           //add a random offset to prevent two player's collider clash and stick together
            spawnedPlayer = PhotonNetwork.Instantiate(PCPlayerPrefabName, spawnPoint.transform.position + randomOffset, spawnPoint.transform.rotation);
            //spawnedPlayer.transform.parent = playersContainer.transform;
            currentPlayer = spawnedPlayer;
            spawnedPlayer.GetComponent<PlayerInput>().SwitchCurrentActionMap(actionMapNameList[level]);
        }
        else if (platformSetter.platform == PlatformSetter.Platforms.vr) //It means mobile or VR but cant distinguish between them
        {
            Vector3 randomOffset = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            //add a random offset to prevent two player's collider clash and stick together
            spawnedPlayer = PhotonNetwork.Instantiate(VRPlayerPrefabName, spawnPoint.transform.position + randomOffset, spawnPoint.transform.rotation);
            //spawnedPlayer.transform.parent = playersContainer.transform;
            currentPlayer = spawnedPlayer;
        }
    }

    public virtual void InitialiseLevel() //inherit
    {
    }

    public virtual void Sender_SyncLevel()
    {
    }

    public IEnumerator GetPartnerPlayerReference()
    {
        yield return new WaitUntil(() => (GameObject.FindGameObjectsWithTag("Player").Length > 1)); //Wait until it get its partner's photon view
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (!go.GetComponent<PhotonView>().IsMine)
            {
                partnerPlayer = go;
            }
        }
    }

    [PunRPC]
    public virtual void Receiver_SyncLevel(bool state)
    {
    }

    public void DisconnectionHandling()
    {
        PhotonNetwork.Destroy(spawnedPlayer);
    }

    public void PlayerDamageHandler()
    {

    }
}
