using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    protected RangeChecker rangeChecker;

    public virtual void VoidInteract() 
    {
    }

    
    //TODO: add interact that return different type
}
