using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region general
    [SerializeField]
    private float switchTargetInterval;
    private Animator animator;
    #endregion

    #region attack general
    [SerializeField]
    private float attackInterval;
    private enum AttackType
    {
        stone, fireBall, wave
    }
    #endregion

    #region stone_attack
    [SerializeField]
    private int stoneNumber;
    [SerializeField]
    private GameObject stonePrefab;
    [SerializeField]
    private Vector3 randomStoneMinPoint;
    [SerializeField]
    private Vector3 randomStoneMaxPoint;
    [SerializeField]
    private Vector3 rejectMinPoint;
    [SerializeField]
    private Vector3 rejectMaxPoint;
    #endregion

    private LevelManager_Base levelManager;

    private GameObject currentTarget;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        levelManager = LevelManager_Base.Instance;
        StartCoroutine(SearchTarget());
        StartCoroutine(AttackCoroutine());
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

    private IEnumerator AttackCoroutine()
    {
        while(true)
        {
            Debug.Log("New Round of attack!");
            #region Choose Attack
            int attackIndex = Random.Range(0, System.Enum.GetValues(typeof(AttackType)).Length);
            attackIndex = 0; // hard code to test stone attack, remove it later
            #endregion
            AttackType attack = (AttackType)attackIndex;
            switch (attack)
            {
                case AttackType.stone:
                    StoneAttack();
                    break;
                default:
                    StoneAttack();
                    break;
            }
            yield return new WaitForSeconds(attackInterval);
        }
    }

    private void StoneAttack()
    {
        animator.SetTrigger("Scream");
        for (int i = 0; i<stoneNumber; i++)
        {
            float randomX = Random.Range(randomStoneMinPoint.x, randomStoneMaxPoint.x);
            
            while (rejectMinPoint.x < randomX && randomX < rejectMaxPoint.x)
            {
                randomX = Random.Range(randomStoneMinPoint.x, randomStoneMaxPoint.x);
            }
           
            float randomY = Random.Range(randomStoneMinPoint.y, randomStoneMaxPoint.y);

            float randomZ = Random.Range(randomStoneMinPoint.z, randomStoneMaxPoint.z);
            while (rejectMinPoint.z < randomZ && randomZ < rejectMaxPoint.z)
            {
                randomZ = Random.Range(randomStoneMinPoint.z, randomStoneMaxPoint.z);
            }

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);
            GameObject stone = Instantiate(stonePrefab, spawnPosition, Quaternion.identity);
        }
    }
}


