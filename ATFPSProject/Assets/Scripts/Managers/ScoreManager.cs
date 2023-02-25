using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float currentLevelScore;
    public float level1Score;
    public float level2Score;
    public float level3Score;


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
}
