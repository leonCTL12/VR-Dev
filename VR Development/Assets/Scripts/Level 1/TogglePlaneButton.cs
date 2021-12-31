using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaneButton : InteractableObject
{
    public override void VoidInteract()
    {
        base.VoidInteract();
        Debug.Log("Toggle");
    }
}
