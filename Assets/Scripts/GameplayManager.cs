﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    DateTime currentTime = DateTime.UtcNow;
    public Text score;
    public static List<ScoreList> dataScore;
    public static int timeFixed;
    private string inputData;

    //static List<ScoreList> dataScore = new List<ScoreList>();
    [Obsolete]
    void Start()
    {
        dataScore = new List<ScoreList>();
        if(WinBox.level == "SampleScene")
        {
            if(PlayerPrefs.GetInt("topScore1")<PlayerPrefs.GetInt("temp"))
            {
                PlayerPrefs.SetInt("topScore1", MoveSphere.lastScore);
            }
            score.text = Play.user_id + " mendapatkan skor " + MoveSphere.lastScore +
            " di level 1, Top Skor di Level 1 adalah " + PlayerPrefs.GetInt("topScore1");
        }
        else if(WinBox.level == "SampleScene2")
        {
            if(PlayerPrefs.GetInt("topScore2")<PlayerPrefs.GetInt("temp"))
            {
                PlayerPrefs.SetInt("topScore2", MoveSphere.lastScore);
            }
            score.text = Play.user_id + " mendapatkan skor " + MoveSphere.lastScore +
            " di level 2, Top Skor di Level 2 adalah " + PlayerPrefs.GetInt("topScore2");
        }
        else if(WinBox.level == "SampleScene3")
        {
            if(PlayerPrefs.GetInt("topScore3")<PlayerPrefs.GetInt("temp"))
            {
                PlayerPrefs.SetInt("topScore3", MoveSphere.lastScore);
            }
            score.text = Play.user_id + " mendapatkan skor " + MoveSphere.lastScore +
            " di level 3, Top Skor di Level 3 adalah " + PlayerPrefs.GetInt("topScore3");
        }
        dataScore.Add(new ScoreList(Play.user_id, MoveSphere.lastScore, MoveSphere.limit, MoveSphere.shots, MoveSphere.jump, timeFixed, WinBox.level));
        StoreData();
        SendtoGoogle send = gameObject.GetComponent<SendtoGoogle>();
        send.Send();        
        MoveSphere.lastScore = 0;
        MoveSphere.lastScoreEnemy = 0;
    }

    public void StoreData()
    {
        foreach(ScoreList a in dataScore)
        {
            // Debug.Log(a.nameString + "," + a.scoreInt + "," + a.limit + "," + a.shots + "," + a.jump + "," + a.level);
            inputData =  DateTime.Now.ToString("dd/MM/yyyy   hh:mm:ss tt") + "," + a.nameString + "," + a.scoreInt + "," + a.limit + "," + a.shots + "," + a.jump + "," + a.level;
        }
        Debug.Log(dataScore);
        string filePath = getPath();
    
        StreamWriter writer = new StreamWriter(filePath, append: true);
    
        writer.WriteLine(inputData);

        writer.Flush();
        writer.Close();
        enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            UnityEngine.SceneManagement.SceneManager.LoadScene(WinBox.level);
        /*if(Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if(firstTouch.position.x > screenCenterX)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            }
            else if(firstTouch.position.x < screenCenterX)
            {
                NextScene();
            }
        } */

    }
    public void NextScene(string scenename)
    {
        SceneManager.LoadSceneAsync(scenename);
    }

    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/"  + "Saved_Inventory.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_Inventory.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_Inventory.csv";
#else
        return Application.dataPath +"/"+"Saved_Inventory.csv";
#endif
    }
}
