using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Base : MonoBehaviour
{
    [SerializeField]
    protected Camera fpsCam;
    [SerializeField]
    protected Transform attackPoint;

    public virtual void Fire()
    {
        
    }

    public virtual void CancelFire() { }
}
