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
            Debug.Log("Set Trigger");
            go.GetComponent<Animator>().SetTrigger("Conduct");
            yield return new WaitForSeconds(clip.length-animationOffset);
        }
    }
}
