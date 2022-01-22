using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Gun_Base
{
    [SerializeField]
    private GameObject analyticalLazer;
    [SerializeField]
    private ThirdPersonWandPowerBeam thirdPersonPowerBeam;

    private float startTime;

    private bool countTime = false;

    private bool firing = false;

    private Boss boss;

    private float bossThreshold;

    private void Start()
    {
        boss = Boss.BossInstance;
        bossThreshold = boss.revealWeakSpotsThreshold;
    }

    private void Update()
    {
        if (countTime)
        {
            float timePassed = Time.time - startTime;
            //Debug.Log("Time Passed: " + timePassed);
            if (timePassed > boss.revealWeakSpotsThreshold)
            {
                Debug.Log("Reveal Weak Spots!");
                boss.RevealWeakSpots();
                CancelFire();
            }
        }

        if (firing)
        {
            //Find the exact hit position using a raycast
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            //check if ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "WeakSpotsRevealCollider")
                {
                    countTime = true;
                    thirdPersonPowerBeam.targetPoint = hit.point;
                }
                else
                {
                    countTime = false;
                    startTime = Time.time; //reset start time;
                    thirdPersonPowerBeam.targetPoint = hit.point;
                }
            } else
            {
                thirdPersonPowerBeam.targetPoint = ray.GetPoint(75);
                Debug.Log("ray point = " + ray.GetPoint(75));
            }
        }
    }

    public override void Fire()
    {
        analyticalLazer.SetActive(true);
        thirdPersonPowerBeam.gameObject.SetActive(true);
        base.Fire();
        firing = true;
        startTime = Time.time;
        countTime = true;
    }

    public override void CancelFire()
    {
        base.CancelFire();
        analyticalLazer.SetActive(false);
        thirdPersonPowerBeam.gameObject.SetActive(false);
        countTime = false;
        firing = false;
    }
}
