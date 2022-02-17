using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class Player_BossFight : MonoBehaviour
{
    [SerializeField]
    private float maxHP; //use float so that the division can return a float
    [SerializeField]
    public PlayerUI playerUI;
    [SerializeField]
    public bool testing_purposeImmune;
    [SerializeField]
    private ThirdPersonPresenter_Shooter presenter;
    private PlayerSFX playerSFX;

    private float currentHP;
    public bool waitingForResurrection;
    private PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        playerSFX = GetComponent<PlayerSFX>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHP = maxHP;
        playerUI.FillHPSlider(currentHP / maxHP);
        waitingForResurrection = false;
        if(!photonView.IsMine) { enabled = false; }
    }

    public void ReceiveDamage(float damage)
    {
        if(testing_purposeImmune || waitingForResurrection) { return; }

        if(!photonView.IsMine) { return; }

        currentHP -= damage;
        playerUI.FillHPSlider(currentHP / maxHP);
        playerSFX.PlayBleed();

        if(currentHP <= 0 )
        {
            currentHP = 0;
            DeathHandler();
        } else
        {
            playerUI.ShowOnScreenHurt();
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