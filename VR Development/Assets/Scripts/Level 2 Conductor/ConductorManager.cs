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

    private void Start()
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
            StartCoroutine(PlayAnimationQueue()); //restart the loop
        } else
        {
            Debug.Log("You Win!");
            GetComponent<Animator>().SetTrigger("Clear");
        }
    }
}
