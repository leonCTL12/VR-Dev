using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConductorGap : InteractableObject
{
    [SerializeField]
    private GameObject leftHand;
    private Animator leftHandAnimator;
    [SerializeField]
    private GameObject rightHand;
    [SerializeReference]
    private Transform playerFixPoint;
    [SerializeField]
    private Transform cameraFixPoint;
    private Animator rightHandAnimator;
    private LevelManager_Puzzle levelManager;
    public Player_Puzzle currentGripPlayer;

    public bool gapClosed = false;
    private bool rightHandGripped = false;
    private bool leftHandGripped = false;
    private PhotonView photonView;

    private void Awake()
    {
        leftHandAnimator = leftHand.GetComponent<Animator>();
        rightHandAnimator = rightHand.GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        levelManager = (LevelManager_Puzzle)LevelManager_Base.Instance;
    }

    public override void Interact_R()
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        levelManager.TeleportPlayerTo(playerFixPoint, cameraFixPoint); //dont need to handle in RPC function becoz I used photon view to sync player's position and rotation
        photonView.RPC("Interact_Sync", RpcTarget.All, true, true);
        currentGripPlayer = levelManager.currentPlayer.GetComponent<Player_Puzzle>();
    }

    public override void Cancel_R()
    {
        base.Cancel_R();
        if (!playerInRange) { return; }
        photonView.RPC("Interact_Sync", RpcTarget.All, true, false);
        currentGripPlayer = null;
    }

    public override void Interact_L()
    {
        base.Interact_L();
        if (!playerInRange) { return; }
        levelManager.TeleportPlayerTo(playerFixPoint, cameraFixPoint); //dont need to handle in RPC function becoz I used photon view to sync player's position and rotation
        photonView.RPC("Interact_Sync", RpcTarget.All, false, true);
        currentGripPlayer = levelManager.currentPlayer.GetComponent<Player_Puzzle>();
    }

  

    public override void Cancel_L()
    {
        base.Cancel_L();
        if (!playerInRange) { return; }
        photonView.RPC("Interact_Sync", RpcTarget.All, false, false);
        currentGripPlayer = null;
    }



    [PunRPC]
    private void Interact_Sync(bool right, bool grip)
    {
        if (right)
        {
            HandGrip(Hand.rightHand, grip); //set false: not for playing release animation, just for reset the state to idle
            rightHandGripped = grip;
        }
        else
        {
            HandGrip(Hand.leftHand, grip);
            leftHandGripped = grip;
        }
        gapClosed = rightHandGripped && leftHandGripped;
        if (!grip)
        {
            GameObject targetHand = right ? rightHand : leftHand;
            targetHand.SetActive(false);
        }
    }

    private void HandGrip(Hand hand, bool grip)
    {
        switch (hand)
        {
            case Hand.leftHand:
                leftHand.SetActive(grip);
                leftHandAnimator.SetBool("Grip", grip);
                break;
            case Hand.rightHand:
                rightHand.SetActive(grip);
                rightHandAnimator.SetBool("Grip", grip);
                break;
        }
    }


}
