using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlanesManager : MonoBehaviour
{
    [SerializeField]
    private TogglePlaneButton[] buttons;
    private static TogglePlanesManager _instance;
    public static TogglePlanesManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    private bool redState = true; 
    public bool redState_GetOnly
    {
        get { return redState; }
    }

    private void Awake()
    {
        if (TogglePlanesManager.Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangePlaneState(bool toggle = true)
    {
        redState = toggle ? !redState : redState;
        foreach (Transform child in transform)
        {
            child.GetComponent<TogglePlane>().Toggle(redState);
        }

        foreach (TogglePlaneButton btn in buttons)
        {
            btn.ChangeButtonColor(redState);
        }
    }
    public void Initialse()
    {
        ChangePlaneState(false);
    }

    public void ReceiveSync(bool state)
    {
        redState = state;
        ChangePlaneState(false);
    }
}
