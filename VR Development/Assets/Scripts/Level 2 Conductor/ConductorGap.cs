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
    private Animator rightHandAnimator;
    private LevelManager_Base levelManager;

    private void Awake()
    {
        leftHandAnimator = leftHand.GetComponent<Animator>();
        rightHandAnimator = rightHand.GetComponent<Animator>();
        levelManager = LevelManager_Base.Instance;
    }

    public override void Interact_R()
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        HandGrip(Hand.rightHand,true);
        levelManager.TeleportPlayerTo(playerFixPoint);
    }

    public override void Interact_L()
    {
        base.Interact_L();
        if (!playerInRange) { return; }
        HandGrip(Hand.leftHand, true);
        levelManager.TeleportPlayerTo(playerFixPoint);
    }

    public override void Cancel_L()
    {
        base.Cancel_L();
        if (!playerInRange) { return; }
        leftHand.SetActive(false);
        HandGrip(Hand.leftHand, false);
    }

    public override void Cancel_R()
    {
        base.Cancel_R();
        if (!playerInRange) { return; }
        rightHand.SetActive(false);
        HandGrip(Hand.rightHand, false); //not for playing release animation, just for reset the state to idle

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
