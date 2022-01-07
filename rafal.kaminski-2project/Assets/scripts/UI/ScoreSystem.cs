using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class ScoreSystem : MonoBehaviour
{
    public WinLossController winLossController;
    private float timeCount;
    public float startTime = 121f;
    public int playerScore = 0;
    public TextMeshProUGUI timeCountUI;
    public TextMeshProUGUI playerScoreUI;
    public TextMeshProUGUI endScore;
    public TextMeshProUGUI lostScore;


    private void Start()
    {
        timeCount = startTime;
        DataManagement.dataManagement.GameLoad();
       
    }

    void Update()
    {
        
        timeCount -= 1 * Time.deltaTime;
        timeCountUI.text = "Time Count:" + (int)timeCount;
        playerScoreUI.text = "Score:" + playerScore;
        endScore.text = ("Score:" + playerScore);
        lostScore.text = ("Score:" + playerScore);

        if (timeCount <= 0)
        {
            timeCount = 0;
            SceneManager.LoadScene("Menu");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EndLevel")
        countScore();
        DataManagement.dataManagement.GameSave();

        if (collision.gameObject.tag == "Key")
            playerScore += 10;
        Destroy(collision.gameObject);
        
    }

    void countScore()
    {
       
        playerScore = playerScore + (int)(timeCount * 10);
        DataManagement.dataManagement.highScore = playerScore + (int)(timeCount * 10);
        DataManagement.dataManagement.GameSave();
        
    }


}
