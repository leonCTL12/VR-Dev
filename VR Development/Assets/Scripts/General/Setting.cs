using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    private static Setting _instance;

    public bool voiceChatEnabled = true;

    public static Setting Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }


    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
