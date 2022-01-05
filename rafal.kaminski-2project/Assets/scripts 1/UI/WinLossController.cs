using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossController : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject lostLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void LostLevel()
    {
        lostLevelUI.SetActive(true);
    }
        
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
        }
    }
}
