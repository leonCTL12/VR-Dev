using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region general
    [SerializeField]
    private float switchTargetInterval;
    [SerializeField]
    private GameObject[] weakSpotsArray;
    private Animator animator;
    private static Boss instance;
    public static Boss BossInstance
    {
        get
        {
            return instance;
        }
    }
    public float revealWeakSpotsThreshold;
    private int weakSpotsCount;
    #endregion

    #region attack general
    [SerializeField]
    private float attackInterval;
    [SerializeField]
    private float initialAttackWait;
    private enum AttackType
    {
        stone, fireBall, lazer
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

    #region fireBall_attack
    [SerializeField]
    private GameObject fireBallPrefab;
    [SerializeField]
    private Transform mouthTransform;
    #endregion

    #region lazer_attack
    [SerializeField]
    private GameObject lazerLauncher;
    private Animator lazerAnimator;
    #endregion

    private LevelManager_Base levelManager;

    private GameObject currentTarget;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lazerAnimator = lazerLauncher.GetComponent<Animator>();
        instance = this;
        foreach (GameObject spot in weakSpotsArray)
        {
            spot.SetActive(false);
        }
        weakSpotsCount = weakSpotsArray.Length;
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
        yield return new WaitForSeconds(initialAttackWait); 
        while(true)
        {
            #region Choose Attack
            int attackIndex = Random.Range(0, System.Enum.GetValues(typeof(AttackType)).Length);
            #endregion
            AttackType attack = (AttackType)attackIndex;
            switch (attack)
            {
                case AttackType.stone:
                    StartCoroutine(StoneAttack());
                    break;
                case AttackType.fireBall:
                    yield return StartCoroutine(FireBallAttack()); ;
                    break;
                case AttackType.lazer:
                    yield return StartCoroutine(LazerAttack()); ;
                    break;
                default:
                    StartCoroutine(StoneAttack());
                    break;
            }
            yield return new WaitForSeconds(attackInterval);
        }
    }

    private IEnumerator StoneAttack()
    {
        animator.SetTrigger("Scream");
        yield return new WaitForSeconds(0.5f);

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

    private IEnumerator FireBallAttack() //I think the reason that does not work is because of the scale of the world
    {
        animator.SetTrigger("Take Off");
        yield return new WaitForSeconds(2.5f);
        animator.SetTrigger("Fire");

        GameObject fireBall = Instantiate(fireBallPrefab, mouthTransform.position, Quaternion.identity);
        fireBall.GetComponent<AttackItem_FireBall>().targetTransform = currentTarget.transform;

        yield return new WaitForSeconds(Random.Range(1.1f, 4f));
        animator.SetTrigger("Land");
    }

    private IEnumerator LazerAttack()
    {
        animator.SetTrigger("Tail");
        lazerLauncher.SetActive(true);
        yield return new WaitForSeconds(1);
        lazerAnimator.SetTrigger("Launch");
        yield return new WaitForSeconds(0.5f);
        lazerLauncher.SetActive(false);
    }

    public void RevealWeakSpots()
    {
        weakSpotsArray[weakSpotsCount - 1].SetActive(true);
    }
}


