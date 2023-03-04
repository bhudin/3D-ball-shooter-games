using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : IComparable<ScoreList>
{
    public string nameString, level;
    public int scoreInt;
    public ScoreList(string newName, int newScore, string newLevel)
    {
        nameString = newName;
        scoreInt = newScore;
        level = newLevel;
    }
    public int CompareTo(ScoreList other)
    {
        if(other == null)
        {
            return 1;
        }
        return scoreInt - other.scoreInt;
    }
}
