using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSFX : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip scream;
    [SerializeField]
    private AudioClip fireBall;
    [SerializeField]
    private AudioClip tailAttack;
    [SerializeField]
    private AudioClip lazerSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StoneAttackSFX()
    {
        audioSource.PlayOneShot(scream);
    }

    public void FireBallSFX()
    {
        audioSource.PlayOneShot(fireBall);
    }

    public void TailAttackSFX()
    {
        audioSource.PlayOneShot(tailAttack);
    }

    public void LazerLaunchSFX()
    {
        audioSource.PlayOneShot(lazerSound);
    }
}
