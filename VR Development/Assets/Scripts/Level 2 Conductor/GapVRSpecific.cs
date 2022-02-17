using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapVRSpecific : MonoBehaviour
{
    [SerializeField]
    private ConductorGap gap;

    [SerializeField]
    private bool rightGap;

    private LevelManager_Puzzle levelManager;


    private void Start()
    {
        levelManager = (LevelManager_Puzzle)LevelManager_Base.Instance;
    }

    public void Interact()
    {
        gap.Interact(rightGap, true, false);
        gap.currentGripPlayer = levelManager.currentPlayer.GetComponent<Player_Puzzle>();
    }

    public void Cancel()
    {
        gap.Interact(rightGap, false, false);
        gap.currentGripPlayer = null;
    }
}
