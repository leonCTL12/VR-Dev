using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSetter : MonoBehaviour
{
    public bool forceVR;

    [SerializeField]
    private bool mobilePlatformBuild;

    private static PlatformSetter instance;


    public enum Platforms
    {
        pc,
        vr,
        mobile
    }

    [HideInInspector]
    public Platforms platform;

    public static PlatformSetter Instance
    {
        get { return instance; }
        set { instance = value; }
    }


    private void Awake()
    {

        if(Instance != null)
        {
            Destroy(this.gameObject); 
        } 
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        SetPlatform();
    } 

    private void SetPlatform()
    {
        #region TempCode
        if (forceVR)
        {
            platform = Platforms.vr;
            return;
        }
        #endregion

        if (mobilePlatformBuild)
        {
            platform = Platforms.mobile;
        }
        else if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            platform = Platforms.pc;
        }
        else if (SystemInfo.deviceType.ToString() == "Handheld") //It means mobile or VR but cant distinguish between them
        {
            platform = Platforms.vr;
        }

    }


}
