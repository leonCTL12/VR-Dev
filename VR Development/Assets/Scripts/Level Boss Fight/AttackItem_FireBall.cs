using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem_FireBall : AttackItem
{
    [SerializeField]
    private float speed;

    public Transform targetTransform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7) //layer of ground: 7
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            //TODO: add logic to damage player
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
