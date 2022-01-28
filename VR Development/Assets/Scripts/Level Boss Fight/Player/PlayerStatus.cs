using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private float maxHP; //use float so that the division can return a float
    [SerializeField]
    public PlayerUI playerUI;
    [SerializeField]
    public bool testing_purposeImmune;
    [SerializeField]
    private ThirdPersonPresenter_Shooter presenter;

    private float currentHP;
    public bool waitingForResurrection;
    private PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHP = maxHP;
        playerUI.FillHPSlider(currentHP / maxHP);
        waitingForResurrection = false;
        if(!photonView.IsMine) { enabled = false; }
        //remove later
        testing_purposeImmune = !PhotonNetwork.IsMasterClient;
    }

    public void ReceiveDamage(float damage)
    {
        if(testing_purposeImmune || waitingForResurrection) { return; }

        if(!photonView.IsMine) { return; }

        currentHP -= damage;
        playerUI.FillHPSlider(currentHP / maxHP);
        if(currentHP <= 0 )
        {
            currentHP = 0;
            DeathHandler();
        }
    }

    private void DeathHandler()
    {
        GetComponent<PlayerInput>().enabled = false;
        playerUI.ShowAndHideDeathPanel(true);
        presenter.ShowDeath();
        waitingForResurrection = true;
    }

    public void ResurrectionHandler()
    {
        GetComponent<PlayerInput>().enabled = true;
        playerUI.ShowAndHideDeathPanel(false);
        waitingForResurrection = false;
        currentHP = maxHP;
        playerUI.FillHPSlider(currentHP / maxHP);
    }
}
