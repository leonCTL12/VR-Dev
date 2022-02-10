using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelManager_TogglePlane : LevelManager_Puzzle
{
    private TogglePlanesManager togglePlanesManager;

    public override void InitialiseLevel()
    {
        base.InitialiseLevel();
        togglePlanesManager.Initialse();
    }

    protected override void Start()
    {
        base.Start();
        togglePlanesManager = TogglePlanesManager.Instance;
    }

    public override void Sender_SyncLevel()
    {
        base.Sender_SyncLevel();
        photonView.RPC("Receiver_SyncLevel", RpcTarget.Others, togglePlanesManager.redState_GetOnly);
    }

    [PunRPC]
    public override void Receiver_SyncLevel(bool state)
    {
        base.Receiver_SyncLevel(state);
        togglePlanesManager.ReceiveSync(state);
    }

}
