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

    private LevelManager levelManager;

    private bool redState = true;

    private void Awake()
    {
        clicker = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        levelManager = LevelManager.Instance;
    }

    public override void VoidInteract()
    {
        base.VoidInteract();
        if(!playerInRange) { return; }

        clicker.GetComponent<MeshRenderer>().material = redState ? blueMaterial : redMaterial;
        redState = !redState;
        levelManager.TogglePlane(redState);
    }

    

}
