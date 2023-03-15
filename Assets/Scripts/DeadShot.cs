using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShot : MonoBehaviour
{
    public float Timer = 1f;
    private static int lives = 2;
    public Transform projectile;
    void Update()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(projectile.gameObject);
        }
    }
    public GameObject enemy;
    public void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "ShootingEnemy" && lives >= 0)
        {
            lives-=1;
            Destroy(enemy);
        }
        if (coll.gameObject.name == "ShootingEnemy" && lives < 0)
        {
            MoveSphere.lastScoreEnemy += 20;
            Destroy(coll.gameObject);
            Destroy(enemy);
            lives = 2;
        }
    }
}
