using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeakSpot : MonoBehaviour
{
    [SerializeField]
    private GameObject normalParticle;
    [SerializeField]
    private GameObject onHitParticle;
    private PhotonView photonView;
    private Boss boss;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        boss = Boss.BossInstance;
        normalParticle.SetActive(true);
        onHitParticle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) //bullet layer
        {
            Debug.Log("WeakSpots Hit!");
            //TODO: inform boss that its weak spot is hit
            boss.OnWeakSpotHit();
            photonView.RPC("OnDestoryWeakSpot", RpcTarget.All);
        }
    }
    
    private IEnumerator DestroyWeakSpotCoroutine()
    {
        normalParticle.SetActive(false);
        onHitParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    [PunRPC]
    private void OnDestoryWeakSpot()
    {
        GetComponent<BoxCollider>().enabled = false; //to prevent hitting a collider multiple time;
        StartCoroutine(DestroyWeakSpotCoroutine());
    }

}
