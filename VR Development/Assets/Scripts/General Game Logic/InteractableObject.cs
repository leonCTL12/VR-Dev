using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange = false;

    public enum Hand
    {
        leftHand,
        RightHand
    }

    public virtual void VoidInteract() 
    {
    }

    public virtual void VoidInteract(Hand hand)
    {

    }
    
    //TODO: add interact that return different type
}
