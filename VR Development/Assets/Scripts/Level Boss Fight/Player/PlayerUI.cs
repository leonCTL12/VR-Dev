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

    public void FillHPSlider(float amount)
    {
        HPslider.value = amount;
    }
    
    public void DisableWeakSpot(int index)
    {
        Debug.Log("Player UI Recevice");
        weakSpots[index].GetComponent<Animator>().SetTrigger("Outro");
    }
}
