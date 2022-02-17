using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Puzzle : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private GameObject firstPersonElectricShockParticles, thirdPersonElectricShockParticles;
    [SerializeField]
    private float paralysisSec;

    private AudioSource audioSource;
    public bool interactable = true;
    private PhotonView photonView;

    [SerializeField]
    private bool VRPlayer;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        photonView = GetComponent<PhotonView>();
    }

    public void DeathHandler(Transform spawnPoint)
    {
        characterController.enabled = false;
        transform.position = spawnPoint.position;
        characterController.enabled = true;
    }

    public void Teleport(Transform destination, Transform cameraTransform = null)
    {
        characterController.enabled = false;
        transform.position = destination.position;
        transform.rotation = destination.rotation;
        if (cameraTransform != null)
        {
            Debug.Log("camera transform detected");
            cameraTransform.rotation = cameraTransform.rotation; //for gamepad
        }
        characterController.enabled = true;
    }

    public IEnumerator ParalyseForSeconds()
    {
        interactable = false;
        firstPersonElectricShockParticles.SetActive(true);
        //thirdPersonElectricShockParticles.SetActive(true);
        audioSource.Play();
        if(VRPlayer)
        {
            GetComponent<VRController_Puzzle>().ToggleParalysis(false);
        }
        yield return new WaitForSeconds(paralysisSec);
        audioSource.Stop();
        interactable = true;
        firstPersonElectricShockParticles.SetActive(false);
        //thirdPersonElectricShockParticles.SetActive(false);
        if (VRPlayer)
        {
            GetComponent<VRController_Puzzle>().ToggleParalysis(true);
        }
    }

    [PunRPC]
    private void ShowThirdPersonParalysisFX_Sync()
    {
        StartCoroutine(ThirdPersonParalysisFX());
    }


    public void ShowThirdPersonParalysisFX()
    {
        photonView.RPC("ShowThirdPersonParalysisFX_Sync", RpcTarget.Others);
    }

    private IEnumerator ThirdPersonParalysisFX()
    {
        thirdPersonElectricShockParticles.SetActive(true);
        audioSource.Play();
        yield return new WaitForSeconds(paralysisSec);
        thirdPersonElectricShockParticles.SetActive(false);
        audioSource.Stop();
    }
}
