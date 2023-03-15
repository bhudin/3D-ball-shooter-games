using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : IComparable<ScoreList>
{
    public string nameString, level;
    public int scoreInt, limit, shots, jump, playTime;
    public ScoreList(string newName, int newScore, int newLimit, int newShots, int newJump, int time, string newLevel)
    {
        nameString = newName;
        scoreInt = newScore;
        limit = newLimit;
        shots = newShots;
        jump = newJump;
        playTime = time;
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
