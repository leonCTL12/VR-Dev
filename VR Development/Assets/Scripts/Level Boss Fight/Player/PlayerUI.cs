using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Slider HPslider;
    [SerializeField]
    private GameObject[] weakSpots;
    [SerializeField]
    private GameObject deathPanel;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public void FillHPSlider(float amount)
    {
        HPslider.value = amount;
    }
    
    public void DisableWeakSpot(int index)
    {
        Debug.Log("Player UI Recevice");
        weakSpots[index].GetComponent<Animator>().SetTrigger("Outro");
    }

    public void ShowAndHideDeathPanel(bool show)
    {
        deathPanel.SetActive(show);
        audioSource.Play();
    }
}
