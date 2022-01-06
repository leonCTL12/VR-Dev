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
    private Animator rightHandAnimator;

    private void Awake()
    {
        leftHandAnimator = leftHand.GetComponent<Animator>();
        rightHandAnimator = rightHand.GetComponent<Animator>();
    }

    public override void Interact_R()
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        HandGrip(Hand.rightHand);
    }

    public override void Interact_L()
    {
        base.Interact_L();
        if (!playerInRange) { return; }
        HandGrip(Hand.leftHand);
    }
    private void HandGrip(Hand hand)
    {
        switch(hand)
        {
            case Hand.leftHand:
                leftHand.SetActive(true);
                leftHandAnimator.SetBool("Grip",true);
                break;
            case Hand.rightHand:
                rightHand.SetActive(true);
                rightHandAnimator.SetBool("Grip",true);
                break;
        }
    }
}
