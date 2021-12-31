using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaneButton : InteractableObject
{
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material blueMaterial;
    [SerializeField]
    private Transform TogglePlanes;

    private GameObject clicker;

    private bool redState = true;

    private void Awake()
    {
        clicker = transform.GetChild(0).gameObject;
    }

    public override void VoidInteract()
    {
        base.VoidInteract();
        if(!rangeChecker.playerInRange) { return; }

        clicker.GetComponent<MeshRenderer>().material = redState ? blueMaterial : redMaterial;
        redState = !redState;
        TogglePlane();
    }

    private void TogglePlane()
    {
        foreach (Transform child in TogglePlanes)
        {
            child.GetComponent<TogglePlane>().Toggle(redState);
        }
    }

}
