using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class WinBox3 : MonoBehaviour
{
    void Start()
    {
        WinBox.level = "SampleScene3";
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            SceneManager.LoadScene("FinishScene3");
        }
    }
}
