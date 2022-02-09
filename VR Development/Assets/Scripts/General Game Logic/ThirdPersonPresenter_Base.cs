using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPresenter_Base : MonoBehaviour
{
    [SerializeField]
    private float animator_moveSpeed;
    [SerializeField]
    private float animator_speedChangeRate;
    [SerializeField]
    private Animator animator;
    private float animator_speed;
    private float _animationBlend;

    public void Movement(Vector3 move, float currentHorizontalSpeed) 
    {
        float targetSpeed = animator_moveSpeed;

        if (move == Vector3.zero)
        {
            targetSpeed = 0f;
        }

        // a reference to the players current horizontal velocity
        float speedOffset = 0.1f;
        float inputMagnitude = 1f;

        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            animator_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * animator_speedChangeRate);

            // round speed to 3 decimal places
            animator_speed = Mathf.Round(animator_speed * 1000f) / 1000f;
        }
        else
        {
            animator_speed = targetSpeed;
        }
        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * animator_speedChangeRate);
        animator.SetFloat("Speed", _animationBlend);
        animator.SetFloat("MotionSpeed", inputMagnitude);
    }

    public void Ground(bool isGrounded)
    {
        animator.SetBool("Grounded", isGrounded);
    }

    public void Jump(bool jumping)
    {
        animator.SetBool("Jump", jumping);
    }
}
