using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpotBullet : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(SelfDestruction());
    }

    private IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BulletDestroyCollider")
        {
            Destroy(gameObject);
        }
    }
}
