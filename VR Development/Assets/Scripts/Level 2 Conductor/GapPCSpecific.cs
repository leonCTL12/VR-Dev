using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapPCSpecific : InteractableObject
{
    [SerializeReference]
    private Transform playerFixPoint;
    [SerializeField]
    private Transform cameraFixPoint;
    private LevelManager_Puzzle levelManager;

    [SerializeField]
    private ConductorGap gap;


    private void Start()
    {
        levelManager = (LevelManager_Puzzle)LevelManager_Base.Instance;
    }

    public override void Interact_R()
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        levelManager.TeleportPlayerTo(playerFixPoint, cameraFixPoint); //dont need to handle in RPC function becoz I used photon view to sync player's position and rotation
        gap.Interact(true, true, false);
        gap.currentGripPlayer = levelManager.currentPlayer.GetComponent<Player_Puzzle>();
    }

    public override void Cancel_R()
    {
        base.Cancel_R();
        if (!playerInRange) { return; }
        gap.Interact(true, false, true);
        gap.currentGripPlayer = null;
    }

    public override void Interact_L()
    {
        base.Interact_L();
        if (!playerInRange) { return; }
        levelManager.TeleportPlayerTo(playerFixPoint, cameraFixPoint); //dont need to handle in RPC function becoz I used photon view to sync player's position and rotation
        gap.Interact(false, true, true);
        gap.currentGripPlayer = levelManager.currentPlayer.GetComponent<Player_Puzzle>();
    }

  

    public override void Cancel_L()
    {
        base.Cancel_L();
        if (!playerInRange) { return; }
        gap.Interact(false, false, true);
        gap.currentGripPlayer = null;
    }



  


}
