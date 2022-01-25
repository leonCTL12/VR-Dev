using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private float maxHP; //use float so that the division can return a float
    [SerializeField]
    public PlayerUI playerUI;
    [SerializeField]
    public bool testing_purposeImmune;
    private float currentHP;
    public bool waitingForResurrection;

    // Start is called before the first frame update
    private void Start()
    {
        currentHP = maxHP;
        playerUI.FillHPSlider(currentHP / maxHP);
        waitingForResurrection = false;
    }

    public void ReceiveDamage(float damage)
    {
        if(testing_purposeImmune || waitingForResurrection) { return; }
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
        waitingForResurrection = true;
    }
}
