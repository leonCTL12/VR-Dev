using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice;
using Photon.Voice.Unity;

public class VoiceChatController : MonoBehaviour
{
    private Recorder recorder;

    private Speaker speaker;

    private Setting setting;

    private void Awake()
    {
        recorder = GetComponent<Recorder>();
        speaker = GetComponent<Speaker>();
    }

    private void Start()
    {
        setting = Setting.Instance;

        recorder.enabled = setting.voiceChatEnabled;
        speaker.enabled = setting.voiceChatEnabled;
    }




}
