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
    [SerializeField]
    private bool instantKill;
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
    private int currentWeakSpot;
    private int destroyedWeakSpotCounter;
    private int bossHP;
    private PhotonView photonView;
    private enum Phrase
    {
        reveal,hit
    }
    private Phrase currentPhrase = Phrase.reveal;
    private BossSFX bossSFX;
    #endregion

    #region attack general
    [SerializeField]
    private float attackInterval; //attack interval cannot be too low (e.g. 7), coz some of the attack takes more than 7 sec
    [SerializeField]
    private float initalActionWait;
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
    private LazerLauncher lazerLauncher;
    #endregion

    private LevelManager_Base levelManager;

    private GameObject currentTarget;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        bossSFX = GetComponent<BossSFX>();
        
        instance = this;
        foreach (GameObject spot in weakSpotsArray)
        {
            spot.SetActive(false);
            spot.GetComponent<BoxCollider>().enabled = PhotonNetwork.IsMasterClient;
        }
        photonView = GetComponent<PhotonView>();

        bossHP = weakSpotsArray.Length;
    }

    private void Start()
    {
        #region initalise lazer launcher
        lazerLauncher = LazerLauncher.Instance;
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
        ////Wait until player go is spawned
        //yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Player").Length != 0);

        yield return new WaitForSeconds(initalActionWait);

        while (true)
        {
            GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player"); //refresh to check if player disconnected/reconnected
            //Randomly Choose one target;
            int chosenTarget = Random.Range(0, playerList.Length);
            currentTarget = playerList[chosenTarget];
            CheckDeathSwitchTarget();
            photonView.RPC("SetTarget_Remote", RpcTarget.Others, currentTarget == levelManager.partnerPlayer);
            yield return new WaitForSeconds(switchTargetInterval);
        }
    }

    private void CheckDeathSwitchTarget()
    {
        Debug.Log("Current Target null: " + (currentTarget.GetComponent<Player_BossFight>() == null));
        Debug.Log("Level Manager null: " + levelManager == null);
        if (currentTarget.GetComponent<Player_BossFight>().waitingForResurrection && levelManager.partnerPlayer!=null)
        {
            currentTarget = (currentTarget.GetComponent<PlayerController_Base>() == levelManager.partnerPlayer) ? levelManager.currentPlayer.gameObject : levelManager.partnerPlayer.gameObject;
            Debug.Log("Switch Target! Now the player is partner player: " + (currentTarget.GetComponent<PlayerController_Base>() == levelManager.partnerPlayer));
        }
    }
    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(initalActionWait); 
        while(true)
        {
            //Choose Attack
            int attackIndex = Random.Range(0, System.Enum.GetValues(typeof(AttackType)).Length);
            //Generate Stone attack position
            Vector3[] randomRockPosition = null;
            if((AttackType)attackIndex == AttackType.stone)
            {
                randomRockPosition = GenerateRockPosition();
            }

            photonView.RPC("LaunchAttack", RpcTarget.All, attackIndex, randomRockPosition);

            yield return new WaitForSeconds(attackInterval);
        }
    }

    private Vector3[] GenerateRockPosition()
    {
        Vector3[] rockPosition = new Vector3[stoneNumber];
        for (int i = 0; i < stoneNumber; i++)
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
            rockPosition[i] = spawnPosition;
        }
        return rockPosition;
    }

    private IEnumerator StoneAttack(Vector3[] rockPositions)
    {
        animator.SetTrigger("Scream");
        bossSFX.StoneAttackSFX();
        yield return new WaitForSeconds(0.5f);

        foreach(Vector3 position in rockPositions)
        {
            GameObject stone = Instantiate(stonePrefab, position, Quaternion.identity);
        }
    }

    private IEnumerator FireBallAttack() 
    {
        animator.SetTrigger("Take Off");
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("Fire");
        bossSFX.FireBallSFX();
        yield return new WaitForSeconds(1f);
        GameObject fireBall = Instantiate(fireBallPrefab, mouthTransform.position, Quaternion.identity);
        fireBall.GetComponent<AttackItem_FireBall>().targetTransform = currentTarget.transform;

        yield return new WaitForSeconds(2);
        animator.SetTrigger("Land");
    }

    private IEnumerator LazerAttack()
    {
        animator.SetTrigger("Tail");
        bossSFX.TailAttackSFX();
        yield return new WaitForSeconds(1);
        bossSFX.LazerLaunchSFX();
        lazerLauncher.Attack();
    }

    public void RevealWeakSpots()
    {
        if (currentWeakSpot >= weakSpotsArray.Length || currentPhrase != Phrase.reveal)
        {
            return;
        }
        photonView.RPC("RevealWeakSpotSync", RpcTarget.All, currentWeakSpot);
        currentWeakSpot++;
    }

    public void OnWeakSpotHit()
    {
        if (currentPhrase != Phrase.hit) { return; }
        photonView.RPC("OnHitWeakSpot_Sync", RpcTarget.All);
    }

    private void BossDeathHandler()
    {
        StartCoroutine(BossDeathCoroutine());
    }

    private IEnumerator BossDeathCoroutine()
    {
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(0.4f);
        bossSFX.PlayDieSound();
        yield return new WaitForSeconds(4);
        levelManager.EndGameHandler();
        Destroy(gameObject);
    }

    #region RPC Function
    [PunRPC]
    private void OnHitWeakSpot_Sync()
    {
        destroyedWeakSpotCounter++;
        bossHP = weakSpotsArray.Length - destroyedWeakSpotCounter;
        LevelManager_BossFight manager_BossFight = (LevelManager_BossFight)levelManager;
        manager_BossFight.UpdatePlayerUIWeakSpot(bossHP);
        if (destroyedWeakSpotCounter >= weakSpotsArray.Length || instantKill)
        {
            BossDeathHandler();
        }
        currentPhrase = Phrase.reveal;
    }
    [PunRPC]
    private void RevealWeakSpotSync(int weakSpotNumber)
    {
        weakSpotsArray[weakSpotNumber].SetActive(true);
        currentPhrase = Phrase.hit;
    }

    [PunRPC]
    private void SetTarget_Remote(bool myPlayer)
    {
        currentTarget = myPlayer ? levelManager.currentPlayer.gameObject : levelManager.partnerPlayer.gameObject;
    }

    [PunRPC]
    private void LaunchAttack(int attackIndex, Vector3[] rockPositions = null)
    {
        AttackType attack = (AttackType)attackIndex;

        switch (attack)
        {
            case AttackType.stone:
                StartCoroutine(StoneAttack(rockPositions));
                break;
            case AttackType.fireBall:
                StartCoroutine(FireBallAttack()); ;
                break;
            case AttackType.lazer:
                StartCoroutine(LazerAttack()); ;
                break;
            default:
                StartCoroutine(FireBallAttack());
                break;
        }
    }
    #endregion
}


