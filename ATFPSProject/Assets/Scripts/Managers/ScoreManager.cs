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

    public TextMeshProUGUI l1ScoreLetter;
    public TextMeshProUGUI l2ScoreLetter;
    public TextMeshProUGUI l3ScoreLetter;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        SetScoreLetter(l1ScoreLetter, level1Score);
        SetScoreLetter(l2ScoreLetter, level2Score);
        SetScoreLetter(l3ScoreLetter, level3Score);

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

    public void SetScoreLetter(TextMeshProUGUI levelScoreLetter, float levelScore)
    {

        if (levelScore == 0)
        {
            levelScoreLetter.SetText("N/A");
        }

        if (levelScore > 0 && levelScore <= 1000f)
        {
            levelScoreLetter.SetText("F");
        }

        if (levelScore >= 1000 && levelScore <= 1500)
        {
            levelScoreLetter.SetText("E");
        }
        
        if (levelScore >= 1500 && levelScore <= 2000)
        {
            levelScoreLetter.SetText("D");
        }
        
        if (levelScore >= 2000 && levelScore <= 2500)
        {
            levelScoreLetter.SetText("C");
        }

        if (levelScore >= 2500 && levelScore <= 3000)
        {
            levelScoreLetter.SetText("B");
        }
        
        if (levelScore >= 3000 && levelScore <= 3500)
        {
            levelScoreLetter.SetText("A");
        }

        if (levelScore >= 3500)
        {
            levelScoreLetter.SetText("S");
        }
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
