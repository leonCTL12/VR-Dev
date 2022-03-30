using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;

    public void ButtonOnClick(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(i == index);
        }
    }
}
