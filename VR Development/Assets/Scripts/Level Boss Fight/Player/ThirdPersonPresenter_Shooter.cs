using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonPresenter_Shooter : MonoBehaviour
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
    #endregion

    #region general
    private PhotonView photonView;
    #endregion 

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        thirdPersonWandBeam.SetActive(false);
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
    }
    #endregion

}
