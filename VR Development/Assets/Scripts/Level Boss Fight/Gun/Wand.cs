using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Gun_Base
{
    [SerializeField]
    private GameObject analyticalLazer;
    [SerializeField]
    private ThirdPersonPresenter_Shooter presenter;

    private float startTime;

    private bool countTime = false;

    private bool firing = false;

    private Boss boss;

    [SerializeField]
    private float bossThreshold = 5f;

    private void Start()
    {
        boss = Boss.BossInstance;
    }

    private void Update()
    {
        if (countTime)
        {
            float timePassed = Time.time - startTime;
            if (boss == null) //Have to do that coz there may be lag in spawning boss, to ensure it got the boss instance 
            {
                boss = Boss.BossInstance;
            } 
            else if (timePassed > bossThreshold)
            {
                Debug.Log("Reveal Weak Spots!");
                boss.RevealWeakSpots();
                CancelFire();
            }
        }

        if (firing)
        {
            //Find the exact hit position using a raycast
            Ray ray = weaponVR? new Ray(attackPoint.position, transform.up) : fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            //problem: this ray do not rotate with player, it will always draw towards 
            //Update: it rotate with player, just that 3D illusion make it hard to see
            RaycastHit hit;

            //check if ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "WeakSpotsRevealCollider")
                {
                    countTime = true;
                }
                else
                {
                    countTime = false;
                    startTime = Time.time; //reset start time;

                }
                //TODO: add back later
                presenter.ShowBeam(hit.point);
            }
            else
            {
                presenter.ShowBeam(ray.GetPoint(75));
            }
        }
    }

    public override void Fire()
    {
        analyticalLazer.SetActive(true);
        audioSource.Play();
        base.Fire();
        firing = true;
        startTime = Time.time;
        countTime = true;
    }

    public override void CancelFire()
    {
        base.CancelFire();
        analyticalLazer.SetActive(false);
        presenter.ShowBeam(null);
        countTime = false;
        firing = false;
        audioSource.Stop();
    }
}
