using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos;
    public static float shotForce = 1250f;
    public float Timer = 0.2f;
    public int rotateDegree = 45;
    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        Timer -= 1f * Time.deltaTime;
        if (Timer <= 0)
        {
        shotPos.Rotate(0,rotateDegree,0);
        Rigidbody shot = Instantiate(projectile, shotPos.position, Quaternion.identity) as Rigidbody;
        shot.AddForce(shotPos.forward * shotForce);
        Timer = 0.2f;
        }
    }
}
