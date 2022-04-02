using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    private GameObject banVoiceChatIcon;

    private Setting setting;

    private void Awake()
    {
        setting = Setting.Instance;
    }

    public void ButtonOnClick(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(i == index);
        }
    }

    public void VoiceChatButtonOnClick()
    {
        setting.voiceChatEnabled = !setting.voiceChatEnabled;

        banVoiceChatIcon.SetActive(!setting.voiceChatEnabled);
    }


}
