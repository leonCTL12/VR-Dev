using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeakSpotGun : Gun_Base
{
    [SerializeField]
    private string bulletPrefabName;
    [SerializeField]
    private float shootForce;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private ParticleSystem gunShotParticle;

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
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 direction = targetPoint - attackPoint.position;

        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefabName, attackPoint.position, Quaternion.identity);
        bullet.transform.forward = direction.normalized;

        bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        gunShotParticle.Play();
    }

}
