using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip bleedingSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBleed()
    {
        audioSource.PlayOneShot(bleedingSound);
    }
}
