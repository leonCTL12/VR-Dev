using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //Animation
    Animator animator;
    SkinnedMeshRenderer mesh;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";
    [SerializeField]
    private float animationSpeed = 10;

    //Physics Movement
    [SerializeField]
    private GameObject followObject;
    [SerializeField]
    private float followSpeed = 30f;
    [SerializeField]
    private float rotateSpeed = 100f;
    [SerializeField] 
    private Vector3 positionOffset;
    [SerializeField]
    private Vector3 rotationOffset;


    private Transform _followTarget;
    private Rigidbody _body;

    public bool objectGrip = false;
    [SerializeField]
    private float objectGripThreshHold = 0.3f;

    void Start()
    {
        // Animation
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        //Physics Movement
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        //Teleport hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    void Update()
    {
        AnimateHand();

        PhysicsMove();
    }

    private void PhysicsMove()
    {
        // Position
        var positionWithOffset = _followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        //Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var quaternionDifference = rotationWithOffset * Quaternion.Inverse(_body.rotation); //Find the difference in rotation between the controller and hand model
        quaternionDifference.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;

        if(gripTarget > objectGripThreshHold && objectGrip)
        {
            gripTarget = objectGripThreshHold;
        }
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;

        if (triggerTarget > objectGripThreshHold && objectGrip)
        {
            triggerTarget = objectGripThreshHold;
        }
    }   

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand" || other.tag == "Player") return;
        objectGrip = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand" || other.tag == "Player") return;
        objectGrip = false;
    }
}
