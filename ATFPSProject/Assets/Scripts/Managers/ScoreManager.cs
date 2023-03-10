using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{

    public float currentLevelScore;
    public float level1Score;
    public float level2Score;
    public float level3Score;

    private void Start()
    {
        LoadFile();
        SaveFile();
    }

    private void Awake()
    {
        int numOfScoreManagers = FindObjectsOfType<ScoreManager>().Length;
        if (numOfScoreManagers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }



    public void SetLevelScore(string levelName, float score)
    {
        if (levelName == "Level1")
        { level1Score = score; }
        
        if (levelName == "Level2")
        { level2Score = score; }

        if (levelName == "Level3")
        { level3Score = score; }

    }


    public void AddToCurrentScore(float scoreToAdd)
    {
        currentLevelScore += scoreToAdd;
    }

    public void ResetCurrentLevelScore()
    {
        currentLevelScore = 0;
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenWrite(destination);
        }
        else
        {
            file = File.Create(destination);
        }

        GameData data = new GameData(level1Score, level2Score, level3Score);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
            Debug.Log("Save file found");
        }
        else
        {
            Debug.Log("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        level1Score = data.L1Score;
        level2Score = data.L2Score;
        level3Score = data.L3Score;
    }
}
