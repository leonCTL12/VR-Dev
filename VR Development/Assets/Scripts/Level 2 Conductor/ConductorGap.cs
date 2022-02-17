using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConductorGap : MonoBehaviour
{
    public enum Hand
    {
        leftHand,
        rightHand
    }

    private PhotonView photonView;
    [SerializeField]
    private GameObject leftHand;
    private Animator leftHandAnimator;
    [SerializeField]
    private GameObject rightHand;
    private Animator rightHandAnimator;

    public bool gapClosed = false;
    private bool rightHandGripped = false;
    private bool leftHandGripped = false;
    public Player_Puzzle currentGripPlayer;


    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        leftHandAnimator = leftHand.GetComponent<Animator>();
        rightHandAnimator = rightHand.GetComponent<Animator>();
    }

    public void Interact(bool right, bool grip, bool VRPlayer)
    {
        if (VRPlayer)
        {
            photonView.RPC("Interact_Sync", RpcTarget.Others, right, grip, true);
            Interact_Sync(right, grip, false);
        }
        else
        {
            photonView.RPC("Interact_Sync", RpcTarget.All, right, grip, true);
        }
    }

    [PunRPC]
    private void Interact_Sync(bool right, bool grip, bool playAnimation)
    {
        if (right)
        {  
            if (playAnimation)
            {
                HandGrip(Hand.rightHand, grip); //set false: not for playing release animation, just for reset the state to idle
            }
            rightHandGripped = grip;
        }
        else
        {
            if(playAnimation)
            {
                HandGrip(Hand.leftHand, grip);
            }
            leftHandGripped = grip;
        }
        gapClosed = rightHandGripped && leftHandGripped;

        Debug.Log("Gap Closed: " + gapClosed);

        if (!grip && playAnimation)
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
