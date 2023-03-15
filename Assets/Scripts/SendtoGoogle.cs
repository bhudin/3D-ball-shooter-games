using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SendtoGoogle : MonoBehaviour
{
    private string Name, Level;
    private int Score, Limit, Shots, Jump, Time;
    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSch1CBbwuxS3gk2x3rYhsJD8CftdhzNbY2oSlYXoJMFdQelQw/formResponse";

    [System.Obsolete]
    IEnumerator Post(string name, int score, int limit, int shots, int jump, int time, string level) {
        WWWForm form = new WWWForm();
        form.AddField("entry.2085267765", name);
        form.AddField("entry.1358932430", score);
        form.AddField("entry.72040706", limit);
        form.AddField("entry.1644635886", shots);
        form.AddField("entry.180146924", jump);
        form.AddField("entry.42432414", time);
        form.AddField("entry.420205193", level);
        /*
        ** Outdated
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
        */
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    [System.Obsolete]
    public void Send() {
        foreach(ScoreList a in GameplayManager.dataScore)
        {
           Name = a.nameString;
           Score = a.scoreInt;
           Limit = a.limit;
           Shots = a.shots;
           Jump = a.jump;
           Time = a.playTime;
           Level = a.level;
        }
        StartCoroutine(Post(Name, Score, Limit, Shots, Jump, Time, Level));
    }
}
