using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private PlatformSetter platformSetter;

    [SerializeField]
    private GameObject normalMenu, vrMenu;
    private void Start()
    {
        platformSetter = PlatformSetter.Instance;
        ChoosePlatform();
    }

    private void ChoosePlatform()
    {
        bool vrMode = platformSetter.platform == PlatformSetter.Platforms.vr;

        normalMenu.SetActive(!vrMode);
        vrMenu.SetActive(vrMode);
    }

}
