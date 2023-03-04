using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public static string level;
    void Start()
    {
        level = "SampleScene";
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            SceneManager.LoadScene("FinishScene");
        }
    }
}
