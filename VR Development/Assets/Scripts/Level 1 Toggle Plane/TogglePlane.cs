using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlane : MonoBehaviour
{
    public enum colorGroup
    {
        red, blue
    }

    [SerializeField]
    private colorGroup color;

    public void Toggle(bool redState)
    {
        if(redState)
        {
            gameObject.SetActive(color == colorGroup.red);
        } else
        {
            gameObject.SetActive(color == colorGroup.blue);
        }
    }
}
