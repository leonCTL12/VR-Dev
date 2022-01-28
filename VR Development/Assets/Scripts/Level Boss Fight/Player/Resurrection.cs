using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Resurrection : MonoBehaviour
{
    [SerializeField]
    private float resurrectionThreshold;
    [SerializeField]
    private PlayerController_Shooter myPlayer; //To prevent self colliding
    [SerializeField]
    private ThirdPersonPresenter_Shooter thirdPersonPresenter;
    private float startTime;
    private bool counting = false;
    private CapsuleCollider capsuleCollider;
   

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;
    }

    public void ToggleResurrection(bool active)
    {
        capsuleCollider.enabled = active;
        Debug.Log("capsule collider activate!");
        //TODO: maybe add SFX here
    }

    private void Update()
    {
        if (counting)
        {
            float timePassed = Time.time - startTime;
            if(timePassed > resurrectionThreshold)
            {
                Debug.Log("Resurrection!!");
                counting = false;
                thirdPersonPresenter.ShowResurrection();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") {
            Debug.Log("It is player object");
            return; 
        }
        if (other.gameObject.GetComponent<PlayerController_Shooter>() == myPlayer)
        {
            Debug.Log("self colliding!");
            return;
        }
        Debug.Log("resurrection collidered with " + other.gameObject.name);
        startTime = Time.time;
        counting = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit");
        startTime = Time.time;
        counting = false;
    }
}
