using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    private LevelManager_Base manager;

    [SerializeField]
    protected int damage;

    private void Start()
    {
        manager = GetComponentInParent<LevelManager_Base>();
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_BossFight player = other.gameObject.GetComponent<Player_BossFight>();
            if (player.enabled)
            {
                player.ReceiveDamage(damage);
            }
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_BossFight player = other.gameObject.GetComponent<Player_BossFight>();
            if(player.enabled)
            {
                player.ReceiveDamage(damage);
            }
        }
    }
}
