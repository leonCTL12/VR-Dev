using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem_FireBall : AttackItem
{
    [SerializeField]
    private float speed;

    public Transform targetTransform;

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.gameObject.layer == 7) //layer of ground: 7
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (targetTransform != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);
        }
    }
} 
