using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonPresenter_Shooter : MonoBehaviour //Handle all third person logic (in peer)
{
    #region Wand
    [SerializeField]
    private GameObject thirdPersonWandBeam;
    [SerializeField]
    private GameObject wand;
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private Vector3? wandTargetPoint;
    [SerializeField]
    private GameObject thirdPersonModel;
    [SerializeField]
    private ParticleSystem deathParticle;
    [SerializeField]
    private ParticleSystem healParticle;
    [SerializeField]
    private Resurrection resurrection;
    #endregion

    #region general
    private PhotonView photonView;
    private PlayerStatus status;
    #endregion 

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        thirdPersonWandBeam.SetActive(false);
        status = GetComponent<PlayerStatus>();
    }

    public void ShowCorrectWeapon(bool gunUser)
    {
        Debug.Log("I am a gun user: " + gunUser);
        wand.SetActive(!gunUser);
        gun.SetActive(gunUser);
    }

    private void Update()
    {
        if(wandTargetPoint!=null)
        {
            thirdPersonWandBeam.transform.LookAt((Vector3)wandTargetPoint);
        }
    }

    public void ShowBeam(Vector3? targetPoint)
    {
        photonView.RPC("ShowBeam_Sync", RpcTarget.Others, targetPoint);
    }

    public void ShowDeath()
    {
        if(!photonView.IsMine)
        {
            Debug.Log("About to show opponent's death");
        }
        photonView.RPC("ShowDeath_Sync", RpcTarget.Others);
    }

    public void ShowResurrection()
    {
        //3rd person logic for resurrection
        thirdPersonModel.SetActive(true);
        deathParticle.Stop();
        healParticle.Stop();
        resurrection.ToggleResurrection(false);
        photonView.RPC("ShowResurrection_Sync", RpcTarget.Others);
    }

    #region RPC
    [PunRPC]
    private void ShowBeam_Sync(Vector3? targetPoint)
    {
        wandTargetPoint = targetPoint;
        if(targetPoint == null)
        {
            thirdPersonWandBeam.SetActive(false);
        } else
        {
            thirdPersonWandBeam.SetActive(true);
        }
    }

    [PunRPC] 
    private void ShowDeath_Sync()
    {
        thirdPersonModel.SetActive(false);
        deathParticle.Play();
        healParticle.Play();
        resurrection.ToggleResurrection(true);
    }

    [PunRPC]
    private void ShowResurrection_Sync()
    {
        //1st person logic for resurrection
        status.ResurrectionHandler();
    }
    #endregion

}
