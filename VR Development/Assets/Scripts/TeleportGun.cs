using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGun : MonoBehaviour
{
    //refer to https://www.youtube.com/watch?v=wZ2UUOC17AY for projectile gun
    [SerializeField]
    private Camera fpsCam;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private GameObject teleportToken;

    [SerializeField]
    private float shootForce;


    public void Fire()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) //return true if we hit something.
        //{
        //    Debug.Log(hit.transform.name);
        //    Instantiate(teleportToken, hit.transform);
        //}

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

        //Calculate direction from attackPoint to targetPoint
        Vector3 direction = targetPoint - attackPoint.position;

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(teleportToken, attackPoint.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = direction.normalized;

        //Add forces to bullet 
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }
}
