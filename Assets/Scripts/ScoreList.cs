using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : IComparable<ScoreList>
{
    public string nameString, level;
    public int scoreInt, limit, shots, jump;
    public ScoreList(string newName, int newScore, int newLimit, int newShots, int newJump, string newLevel)
    {
        nameString = newName;
        scoreInt = newScore;
        limit = newLimit;
        shots = newShots;
        jump = newJump;
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
