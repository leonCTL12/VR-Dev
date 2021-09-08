using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Menu : MonoBehaviourPunCallbacks
{
    private bool isConnecting = false;
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void SearchForGame()
    {
        isConnecting = true;
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        } 
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster(); //The original implementation is doing nothing
        Debug.Log("ConnectedMaster");
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause); //The original implementation is doing nothing
        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message); //The original implementation is doing nothing
        Debug.Log("No clients have made any rooms");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom(); //The original implementation is doing nothing
        Debug.Log("Client successfully joined room");
        PhotonNetwork.LoadLevel("TestGameScene"); //Load scene

    }
}
