using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataManagement : MonoBehaviour
{
    public static DataManagement dataManagement;
    public int highScore;

    private void Awake()
    {
        if (dataManagement == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement != this)
        {
            Destroy(gameObject);
        }
    }

    public void GameSave()
    {
        BinaryFormatter BinForm = new BinaryFormatter(); //creates a bin formatter
        FileStream file = File.Create(Application.persistentDataPath +"/gameInfo.dat"); //creates file
        gameData data = new gameData(); //create container for data 
        data.highScore = highScore;
        BinForm.Serialize(file, data); //serializes
        file.Close();

    }

    public void GameLoad()
    {
        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            highScore = data.highScore;

        }

    }

}

[Serializable]
class gameData
{
    public int highScore;
}