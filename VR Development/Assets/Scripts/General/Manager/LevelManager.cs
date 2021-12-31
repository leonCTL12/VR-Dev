using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnPoint;
    [SerializeField]
    private GameObject playerPrefab;

    private PlayerController_Base currentPlayer;

    private void Start()
    {
        currentPlayer = Instantiate(playerPrefab).GetComponent<PlayerController_Base>();
    }

    public void DeathHandling()
    {
        currentPlayer.DeathHandler(SpawnPoint.transform);
    }
   
}
