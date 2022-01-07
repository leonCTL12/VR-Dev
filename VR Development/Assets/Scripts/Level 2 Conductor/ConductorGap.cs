using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        leftHandAnimator = leftHand.GetComponent<Animator>();
        rightHandAnimator = rightHand.GetComponent<Animator>();
    }

    private void Start()
    {
        levelManager = LevelManager_Base.Instance;
    }

    public override void Interact_R(PlayerController_Puzzle player)
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        HandGrip(Hand.rightHand,true);
        levelManager.TeleportPlayerTo(playerFixPoint,cameraFixPoint);
        rightHandGripped = true;
        gapClosed = rightHandGripped && leftHandGripped;
        currentGripPlayer = player;
    }

    public override void Interact_L(PlayerController_Puzzle player)
    {
        base.Interact_L();
        if (!playerInRange) { return; }
        HandGrip(Hand.leftHand, true);
        Debug.Log("In conductor gap interact L");
        Debug.Log("level manager null? " + (levelManager == null));
        levelManager.TeleportPlayerTo(playerFixPoint,cameraFixPoint);
        leftHandGripped = true;
        gapClosed = rightHandGripped && leftHandGripped;
        currentGripPlayer = player;
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
        switch(hand)
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
