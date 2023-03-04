using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Text score;
    private static List<ScoreList> dataScore;
    //static List<ScoreList> dataScore = new List<ScoreList>();
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
        dataScore.Add(new ScoreList(Play.user_id, MoveSphere.lastScore, WinBox.level));
        foreach(ScoreList a in dataScore)
        {
            Debug.Log(a.nameString + " " + a.level + " " + a.scoreInt);
        }
        MoveSphere.lastScore = 0;
        MoveSphere.lastScoreEnemy = 0;
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
}
