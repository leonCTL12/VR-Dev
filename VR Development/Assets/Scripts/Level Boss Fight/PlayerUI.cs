using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Slider HPslider;

    public void FillHPSlider(float amount)
    {
        HPslider.value = amount;
    }
    
}
