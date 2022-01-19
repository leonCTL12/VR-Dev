using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpotGun : Gun_Base
{
    [SerializeField]
    private float powerBeamDuration;
    [SerializeField]
    private GameObject powerBeam;
    public override void Fire()
    {
        base.Fire();
       
        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        StartCoroutine(FireParticle());
    }

    private IEnumerator FireParticle()
    {
        powerBeam.SetActive(true);
        yield return new WaitForSeconds(powerBeamDuration);
        powerBeam.SetActive(false);
    }


}
