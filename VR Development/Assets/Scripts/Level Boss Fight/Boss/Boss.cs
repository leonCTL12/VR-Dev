using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Boss : MonoBehaviour
{
    #region general
    [SerializeField]
    private float switchTargetInterval;
    [SerializeField]
    private GameObject[] weakSpotsArray;
    [SerializeField]
    private float lookSpeed;
    private Animator animator;
    private bool masterBoss;
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
    private PhotonView photonView;
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
    private string lazerLauncherName;
    private GameObject lazerLauncher;
    private Animator lazerAnimator;
    #endregion

    private LevelManager_Base levelManager;

    private GameObject currentTarget;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        instance = this;
        foreach (GameObject spot in weakSpotsArray)
        {
            spot.SetActive(false); //set it to false later
        }
        weakSpotsCount = weakSpotsArray.Length;
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        #region initalise lazer launcher
        lazerLauncher = GameObject.Find(lazerLauncherName);
        lazerAnimator = lazerLauncher.GetComponent<Animator>();
        lazerLauncher.SetActive(false);
        #endregion

        levelManager = LevelManager_Base.Instance;
      
        masterBoss = PhotonNetwork.IsMasterClient;

        if (masterBoss)
        {
            StartCoroutine(SearchTarget());
            StartCoroutine(AttackCoroutine());
        }
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            var targetRotation = Quaternion.LookRotation(currentTarget.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
        }
    }

    private IEnumerator SearchTarget()
    {
        //Wait until player go is spawned
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Player").Length != 0);

        while (true)
        {
            Debug.Log("Target Switch!");
            GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player"); //refresh to check if player disconnected/reconnected
            //Randomly Choose one target;
            int chosenTarget = Random.Range(0, playerList.Length);
            currentTarget = playerList[chosenTarget];
            photonView.RPC("SetTarget_Remote", RpcTarget.Others, currentTarget.GetComponent<PlayerController_Base>() == levelManager.partnerPlayer);
            yield return new WaitForSeconds(switchTargetInterval);
        }
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(initialAttackWait); 
        while(true)
        {
            //Choose Attack
            int attackIndex = Random.Range(0, System.Enum.GetValues(typeof(AttackType)).Length);
            photonView.RPC("LaunchAttack", RpcTarget.All, attackIndex);
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

    private IEnumerator FireBallAttack() 
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

    #region RPC Function
    [PunRPC]
    private void SetTarget_Remote(bool myPlayer)
    {
        currentTarget = myPlayer ? levelManager.currentPlayer.gameObject : levelManager.partnerPlayer.gameObject;
    }

    [PunRPC]
    private void LaunchAttack(int attackIndex)
    {
        AttackType attack = (AttackType)attackIndex;

        switch (attack)
        {
            case AttackType.stone:
                StartCoroutine(StoneAttack());
                break;
            case AttackType.fireBall:
                StartCoroutine(FireBallAttack()); ;
                break;
            case AttackType.lazer:
                StartCoroutine(LazerAttack()); ;
                break;
            default:
                StartCoroutine(StoneAttack());
                break;
        }
    }
    #endregion
}


