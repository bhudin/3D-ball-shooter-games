using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFire : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos, target;
    public static float shotForce = 1100f;
    public static float Timer = 0.5f, rotateAroundSpeed = 50f, rotationSpeed = 50f;
    public Transform[] patrolPoints;
    private int currentPoint;
    [SerializeField]
    private float moveSpeed = 3f;
    void Start()
    {
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
    }
    void Update()
    {
        Shoot();
        if(transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }
        if(currentPoint>=patrolPoints.Length)
        {
            currentPoint = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }
    public void Shoot()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer <= 0)
        {
        var curRot = shotPos.rotation;
        shotPos.RotateAround(shotPos.position, Vector3.up, rotateAroundSpeed * Time.deltaTime);
        shotPos.rotation = Quaternion.Slerp(curRot, Quaternion.LookRotation(
            target.position - shotPos.position), rotationSpeed*Time.deltaTime);
        Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
        shot.AddForce(shotPos.forward * shotForce);
        Timer = 0.5f;
        }
    }
}