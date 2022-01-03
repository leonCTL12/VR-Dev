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

    private bool redState;
    public bool redState_Getonly
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

    public void TogglePlane()
    {
        redState = !redState;
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
        redState = false;
        TogglePlane();
    }
}
