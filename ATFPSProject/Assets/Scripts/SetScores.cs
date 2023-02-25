using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScores : MonoBehaviour
{

    public TextMeshProUGUI l1ScoreLetter;
    public TextMeshProUGUI l2ScoreLetter;
    public TextMeshProUGUI l3ScoreLetter;

    [SerializeField] ScoreManager scoreManager;

    private void Update()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        SetScoreLetter(l1ScoreLetter, scoreManager.level1Score);
        SetScoreLetter(l2ScoreLetter, scoreManager.level2Score);
        SetScoreLetter(l3ScoreLetter, scoreManager.level3Score);
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
}
