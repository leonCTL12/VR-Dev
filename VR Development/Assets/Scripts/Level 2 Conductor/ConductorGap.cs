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
    private LevelManager_Base levelManager;
    public PlayerController_Puzzle currentGripPlayer;

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
        levelManager = LevelManager_Base.Instance;
    }

    public override void Interact_R()
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        levelManager.TeleportPlayerTo(playerFixPoint, cameraFixPoint); //dont need to handle in RPC function becoz I used photon view to sync player's position and rotation
        photonView.RPC("Interact_Sync", RpcTarget.Others, true);
        Interact_Sync(true);
        currentGripPlayer = (PlayerController_Puzzle)levelManager.currentPlayer;
    }

    [PunRPC]
    private void Interact_Sync(bool right) 
    {
        if(right)
        {
            HandGrip(Hand.rightHand, true);
            rightHandGripped = true;
        } 
        else
        {
            HandGrip(Hand.leftHand, true);
            leftHandGripped = true;
        }
        gapClosed = rightHandGripped && leftHandGripped;
    }

    public override void Interact_L()
    {
        base.Interact_L();
        if (!playerInRange) { return; }
        levelManager.TeleportPlayerTo(playerFixPoint, cameraFixPoint); //dont need to handle in RPC function becoz I used photon view to sync player's position and rotation
        photonView.RPC("Interact_Sync", RpcTarget.Others, false);
        Interact_Sync(false);
        currentGripPlayer = (PlayerController_Puzzle)levelManager.currentPlayer;
    }

    public override void Cancel_L()
    {
        base.Cancel_L();
        if (!playerInRange) { return; }
        leftHand.SetActive(false);
        HandGrip(Hand.leftHand, false);
        leftHandGripped = false;
        gapClosed = rightHandGripped && leftHandGripped;
        currentGripPlayer = null;
    }

    public override void Cancel_R()
    {
        base.Cancel_R();
        if (!playerInRange) { return; }
        rightHand.SetActive(false);
        HandGrip(Hand.rightHand, false); //not for playing release animation, just for reset the state to idle
        rightHandGripped = false;
        gapClosed = rightHandGripped && leftHandGripped;
        currentGripPlayer = null;
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
