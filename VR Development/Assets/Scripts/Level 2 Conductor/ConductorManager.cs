using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] conductors;

    [SerializeField]
    private AnimationClip clip;

    [SerializeField]
    private float animationOffset;

    [SerializeField]
    private PressureSensor pressureSensor;

    public void StartEnergyTransmission()
    {
        StartCoroutine(PlayAnimationQueue());
    }

    private IEnumerator PlayAnimationQueue()
    {
        bool escapeFromBreak = false;
        foreach (GameObject go in conductors)
        {
            ConductorGap gap = go.GetComponent<ConductorGap>();
            if (gap != null)
            {
                if (!gap.gapClosed)
                {
                    escapeFromBreak = true;
                    break;
                } else
                {
                    PlayerController_Puzzle player = gap.currentGripPlayer;
                    StartCoroutine(player.ParalyseForSeconds(gap));
                }
            } else
            {
                go.GetComponent<Animator>().SetTrigger("Conduct");
                yield return new WaitForSeconds(clip.length - animationOffset);
            }
        }

        if(escapeFromBreak)
        {
        } else
        {
            GetComponent<Animator>().SetTrigger("Clear");
        }
        pressureSensor.ResetButton(); //no matter succeed or not, reset the button

    }
}
