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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.DeathHandling(!other.gameObject.GetComponent<PlayerController_Base>().isMine);
        }
    }
}
