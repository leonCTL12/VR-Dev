using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlane : MonoBehaviour
{
    private Animator animator;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip scaleUp, scaleDown;

    public enum colorGroup
    {
        red, blue
    }

    [SerializeField]
    private colorGroup color;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Toggle(bool redState)
    {
        AudioClip clip;
        if (redState)
        {
            animator.SetBool("show", color == colorGroup.red);
            clip = color == colorGroup.red ? scaleUp : scaleDown;
        }
        else
        {
            animator.SetBool("show", color == colorGroup.blue);
            clip = color == colorGroup.blue ? scaleUp : scaleDown;
        }
        audioSource.PlayOneShot(clip);
    }
}
