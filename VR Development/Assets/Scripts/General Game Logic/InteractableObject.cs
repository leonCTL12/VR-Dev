using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class InteractableObject : MonoBehaviourPun
{
    public bool playerInRange = false;

    public enum Hand
    {
        leftHand,
        rightHand
    }

    public virtual void VoidInteract() 
    {
    }

    //Separate as two functions because maybe different hands perform different functions
    public virtual void Interact_R()
    {

    }

    public virtual void Interact_L()
    {

    }
    
    public virtual void Cancel_R()
    {

    }

    public  virtual void Cancel_L()
    {

    }
}
