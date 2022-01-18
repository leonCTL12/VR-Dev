using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Gun_Base
{
    [SerializeField]
    private GameObject analyticalLazer;
    public override void Fire()
    {
        analyticalLazer.SetActive(true);
        base.Fire();
        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Ray Cast Hit: " + hit.collider.gameObject.name);
        }
    }

    public override void CancelFire()
    {
        base.CancelFire();
        analyticalLazer.SetActive(false);
    }
}
