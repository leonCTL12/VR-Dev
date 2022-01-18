using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private float maxHP; //use float so that the division can return a float
    [SerializeField]
    private PlayerUI playerUI;

    private float currentHP;


    // Start is called before the first frame update
    private void Start()
    {
        currentHP = maxHP;
        playerUI.FillHPSlider(currentHP / maxHP);
    }

    public void ReceiveDamage(float damage)
    {
        currentHP -= damage;
        playerUI.FillHPSlider(currentHP / maxHP);
    }

}
