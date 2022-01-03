using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaneButton : InteractableObject
{
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material blueMaterial;

    private GameObject clicker;

    private TogglePlanesManager manager;

    private void Awake()
    {
        clicker = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        manager = TogglePlanesManager.Instance;
    }

    public override void VoidInteract()
    {
        base.VoidInteract();
        if(!playerInRange) { return; }

        manager.Trigger_ChangePlaneState();
    }

    public void ChangeButtonColor(bool redState)
    {
        clicker.GetComponent<MeshRenderer>().material = redState ?  redMaterial : blueMaterial;
    }



}
