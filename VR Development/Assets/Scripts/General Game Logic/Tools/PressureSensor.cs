using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class PressureSensor : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private BoxCollider collider;

    [SerializeField]
    private GameObject particle;

    public UnityEvent onPressed;

    private PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        photonView.RPC("Pressed", RpcTarget.All);
    }

    [PunRPC]
    private void Pressed()
    {
        animator.SetBool("Down", true);
        collider.enabled = false;
        particle.SetActive(false);
        onPressed.Invoke();
    }

    public void ResetButton()
    {
        animator.SetBool("Down", false);
        collider.enabled = true;
        particle.SetActive(true);
    }
}
