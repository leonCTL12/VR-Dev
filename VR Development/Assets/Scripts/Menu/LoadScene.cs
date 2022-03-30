using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    private string[] sceneNames = { "Level 1", "Level 2", "Boss Fight" };

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(sceneNames[index]);
    }
}
