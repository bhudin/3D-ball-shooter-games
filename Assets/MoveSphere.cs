using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    protected bool juump, shoot;
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected Joyshoot joyshoot;
    public static int lastScore = 0, lastScoreEnemy = 0;
    public GameObject Sphere;
    public int playTime = 0;
    public static int tmphigh, tmp2 = 0, tmp3 = 0;
    public Text timeText, scoreText;
    public float odometer = 0f;
    private Scene scene;
    public Rigidbody cylinder;
    public Transform shotPos;
    public float shotForce = 1000f;
    private Rigidbody rg;
    private Vector3 input, oldPos;
    public float speed;
    private float maxSpeed;
    public float moveSpeed;
    public int jumpCount;
    public float mousePos;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        joyshoot = FindObjectOfType<Joyshoot>();
        tmphigh = PlayerPrefs.GetInt("topScore1");
        tmp2 = PlayerPrefs.GetInt("topScore2");
        tmp3 = PlayerPrefs.GetInt("topScore3");
        scene = SceneManager.GetActiveScene();
        oldPos = transform.position;
        jumpCount = 1;
        moveSpeed = 20f;
        speed = 15f;
        maxSpeed = 40f;
        rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        playTime = (int)Time.timeSinceLevelLoad;
        timeText.text = "Time = " + playTime;
        if(!shoot && joyshoot.Pressed)
        {
            shoot = true;
            PlayerShoot();
        }
        if(shoot && !joyshoot.Pressed)
        {
            shoot = false;
        }
        if(!juump && joybutton.Pressed && jumpCount == 1)
        {
            juump = true;
            Jump();
        }
        if(juump && !joybutton.Pressed)
        {
            juump = false;
        }
        if(Input.GetKeyDown("space") && jumpCount == 1)
        {
            Jump();
        }
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f,
                                        rigidbody.velocity.y,
                                        joystick.Vertical * 10f);
        input = new Vector3 (joystick.Horizontal, 0f, joystick.Vertical);
        if(rg.velocity.magnitude < maxSpeed)
        {
            odometer += Vector3.Distance(input, oldPos);
            scoreText.text = "Limit = " + (int)(1000-odometer);
            if((1000-odometer)<1)
            {
                MoveSphere.lastScoreEnemy = 0;
                SceneManager.LoadSceneAsync(scene.name);
            }
            rg.AddForce(input * moveSpeed);
        }
        if(transform.position.y < -1)
        {
            MoveSphere.lastScoreEnemy = 0;
            SceneManager.LoadSceneAsync(scene.name);
        }        
    }
    public void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Plane")
        {
            jumpCount = 1;
        }
    }
    public void Jump()
    {
        Vector3 atas = new Vector3(0,20,0);
        rg.AddForce(atas*speed);
        jumpCount -= 1;
    }
    public void PlayerShoot()
    {
        Rigidbody shot = Instantiate(cylinder, transform.position, Quaternion.identity) as Rigidbody;
        shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * shotForce);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "finishPoint")
        {
            lastScore = (int)((1000-odometer)/playTime)+lastScoreEnemy;
            PlayerPrefs.SetInt("temp",lastScore);
        }
    }
}
