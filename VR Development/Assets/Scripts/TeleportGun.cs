using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGun : MonoBehaviour
{
    [SerializeField]
    private Camera fpsCam;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private GameObject teleportTokenPrefab;

    [SerializeField]
    private float shootForce;

    [System.NonSerialized]
    public GameObject currentTeleportToken;

    public void Fire()
    {
     
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
        currentTeleportToken = Instantiate(teleportTokenPrefab, attackPoint.position, Quaternion.identity);

        //Rotate bullet to shoot direction
        currentTeleportToken.transform.forward = direction.normalized;

        //Add forces to bullet 
        currentTeleportToken.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }
    
}
