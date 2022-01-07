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
        foreach (GameObject go in conductors)
        {
            Debug.Log("go name:" + go.name);
            ConductorGap gap = go.GetComponent<ConductorGap>();
            if (gap != null)
            {
                Debug.Log("Gap Found");
                if (!gap.gapClosed)
                {
                    Debug.Log("Break");
                    StartCoroutine(PlayAnimationQueue()); //restart the loop
                    break;
                } else
                {
                    //TODO: conduct effect;
                    yield return new WaitForSeconds(clip.length - animationOffset);
                }
            } else
            {
                go.GetComponent<Animator>().SetTrigger("Conduct");
                yield return new WaitForSeconds(clip.length - animationOffset);
            }
        }
        StartCoroutine(PlayAnimationQueue()); //restart the loop
    }
}
