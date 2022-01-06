using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
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
    
}
