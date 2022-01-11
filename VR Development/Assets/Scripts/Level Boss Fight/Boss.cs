using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float attackInterval;
    [SerializeField]
    private float switchTargetInterval;

    private LevelManager_Base levelManager;

    private GameObject currentTarget; 

    private void Start()
    {
        levelManager = LevelManager_Base.Instance;
        StartCoroutine(SearchTarget());
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            transform.LookAt(currentTarget.transform);
        }
    }

    private IEnumerator SearchTarget()
    {
        //Wait until player go is spawned
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Player").Length != 0);

        while (true)
        {
            GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player"); //refresh to check if player disconnected/reconnected
            //Randomly Choose one target;
            Random.Range(0, playerList.Length);
            currentTarget = playerList[0];
            yield return new WaitForSeconds(switchTargetInterval);
        }
      
    }

    private IEnumerator MainCoroutine()
    {
        yield return null;
    }
}
