using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Base : MonoBehaviour
{
    [SerializeField]
    protected Camera fpsCam;
    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void Fire()
    {
        
    }

    public virtual void CancelFire() { }
}
