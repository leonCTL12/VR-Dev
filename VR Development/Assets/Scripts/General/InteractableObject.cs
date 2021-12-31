using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange = false;

    public virtual void VoidInteract() 
    {
    }

    
    //TODO: add interact that return different type
}
