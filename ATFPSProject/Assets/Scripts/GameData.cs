using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{

    public float L1Score;
    public float L2Score;
    public float L3Score;

    public GameData (float l1Score, float l2Score, float l3Score)
    {
        L1Score = l1Score;
        L2Score = l2Score;
        L3Score = l3Score;
    }

}
