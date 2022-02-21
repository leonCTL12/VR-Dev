using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip bleedingSound;

    [SerializeField]
    private AudioClip deathSFX;

    [SerializeField]
    private AudioClip respawnSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBleed()
    {
        audioSource.PlayOneShot(bleedingSound);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(deathSFX);
    }

    public void PlayRespawn() 
    {
        audioSource.PlayOneShot(respawnSFX);
    }
}
