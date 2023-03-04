using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public Text userText;
    public GameObject playButton;
    public static string user_id;
    void Start()
    {
        playButton.SetActive(false);
    }
    void Update()
    {
    }
    public void LoadNextScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ContinueClick()
    {
        playButton.SetActive(true);
        user_id = userText.text.ToString();
    }
}
