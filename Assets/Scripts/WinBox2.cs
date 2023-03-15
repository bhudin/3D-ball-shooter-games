using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class WinBox2 : MonoBehaviour
{
    void Start()
    {
        WinBox.level = "SampleScene2";
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            SceneManager.LoadScene("FinishScene2");
        }
    }
}
