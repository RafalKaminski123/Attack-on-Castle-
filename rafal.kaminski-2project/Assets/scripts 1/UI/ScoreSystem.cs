using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private float timeCount = 121;
    public int playerScore = 0;
    public GameObject timeCountUI;
    public GameObject playerScoreUI;


    private void Start()
    {
        DataManagement.dataManagement.GameLoad();
       
    }

    void Update()
    {
        
        timeCount -= Time.deltaTime;
        timeCountUI.gameObject.GetComponent<TextMeshProUGUI>().text = ("Time Count:" + (int)timeCount);
        playerScoreUI.gameObject.GetComponent<TextMeshProUGUI>().text = ("Score:" + playerScore);
        if (timeCount < 0.1f)
        {
            SceneManager.LoadScene("Game");
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
