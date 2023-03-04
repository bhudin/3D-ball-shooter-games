using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadBullet : MonoBehaviour
{
    private Scene scene;
    public float Timer = 1f;
    public Transform projectile;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        Timer -= 0.5f * Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(projectile.gameObject);
        }
    }
    public void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Sphere")
        {
            MoveSphere.lastScoreEnemy = 0;
            SceneManager.LoadScene(scene.name);
        }
        if (coll.gameObject.name == "Plane")
        {
            Destroy(projectile.gameObject);
        }
    }
}
