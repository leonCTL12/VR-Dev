using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlane : MonoBehaviour
{
    private Animator animator;
    public enum colorGroup
    {
        red, blue
    }

    [SerializeField]
    private colorGroup color;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Toggle(bool redState)
    {
        Debug.Log("In Toggle");
        if (redState)
        {
            animator.SetBool("show", color == colorGroup.red);
        }
        else
        {
            animator.SetBool("show", color == colorGroup.blue);
        }
    }
}
