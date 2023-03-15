using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;
    [SerializeField]
    private float moveSpeed = 3f;
    private Scene scene;
    void Start()
    {
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
        scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            MoveSphere.lastScoreEnemy = 0;
            SceneManager.LoadScene(scene.name);
        }
    }
}
