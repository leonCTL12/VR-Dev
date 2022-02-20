using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Slider HPSlider;
    [SerializeField]
    private GameObject[] weakSpots;
    [SerializeField]
    private GameObject deathPanel;
    private Animator animator;

    [SerializeField]
    private bool playerVR;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public void FillHPSlider(float amount)
    {
        HPSlider.value = amount;
        Debug.Log("Receive Call, Slider value = " + HPSlider.value);
    }
    
    public void DisableWeakSpot(int index)
    {
        Debug.Log("Player UI Recevice");
        weakSpots[index].GetComponent<Animator>().SetTrigger("Outro");
    }

    public void ShowAndHideDeathPanel(bool show)
    {
        if (show)
        {
            animator.SetTrigger("Death");
        } else
        {
            animator.SetTrigger("Respawn");
        }
    }

    public void ShowOnScreenHurt()
    {
        animator.SetTrigger("Hurt");
    }
}
