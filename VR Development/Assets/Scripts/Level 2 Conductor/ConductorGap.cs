using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorGap : InteractableObject
{
    [SerializeField]
    private Animator leftHandAnimator;
    [SerializeField]
    private Animator rightHandAnimator;

    public override void VoidInteract(Hand hand)
    {
        base.VoidInteract();
        if (!playerInRange) { return; }
        HandGrip(hand);
    }

    private void HandGrip(Hand hand)
    {
        switch(hand)
        {
            case Hand.leftHand:
                leftHandAnimator.SetTrigger("Grip");
                break;
            case Hand.RightHand:
                rightHandAnimator.SetTrigger("Grip");
                break;
        }
    }
}
