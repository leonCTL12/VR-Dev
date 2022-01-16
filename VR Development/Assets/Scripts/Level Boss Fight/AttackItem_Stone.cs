using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem_Stone : AttackItem
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7) //layer 7 is ground
        {
            Destroy(gameObject);
        }
    }


}
