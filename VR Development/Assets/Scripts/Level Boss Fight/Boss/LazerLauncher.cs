using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerLauncher : MonoBehaviour
{
    public static LazerLauncher Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    private static LazerLauncher _instance;

    private Animator animator;

    private void Awake()
    {
        if(LazerLauncher.Instance != null)
        {
            Destroy(this.gameObject);
        }  else
        {
            LazerLauncher.Instance = this;
        }

        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public void Attack()
    {
        gameObject.SetActive(true);
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        animator.SetTrigger("Launch");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        animator.SetTrigger("Back");
    }

}
