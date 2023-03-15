using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    protected bool juump, shoot;
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected Joyshoot joyshoot;
    public static int lastScore = 0, lastScoreEnemy = 0;
    public GameObject Sphere;
    public int playTime = 0, bensin = 3000;
    public static int tmphigh, tmp2 = 0, tmp3 = 0, limit, shots, jump;
    public Text timeText, scoreText, shotsText;
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
        shots = 0;
        jump = 0;
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
        Sphere = GameObject.Find("Sphere");        
    }
    void Update()
    {
        playTime = (int)Time.timeSinceLevelLoad;
        limit = (int)(bensin - odometer);
        shotsText.text = "Shots = " + shots;
        timeText.text = "Time = " + playTime;
        PlayerCondition();        
        PlayerMove();       
    }
    public void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Plane")
        {
            jumpCount = 1;
        }
    }

    public void PlayerMove()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f,
                                        rigidbody.velocity.y,
                                        joystick.Vertical * 10f);
        input = new Vector3 (joystick.Horizontal, 0f, joystick.Vertical);
        if(rg.velocity.magnitude < maxSpeed)
        {
            odometer += Vector3.Distance(input, oldPos);
            scoreText.text = "Limit = " + (int)(bensin-odometer);
            if((bensin-odometer)<1)
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

    public void PlayerCondition()
    {
        if(!shoot && joyshoot.Pressed)
        {
            shoot = true;
            PlayerShoot();
            shots += 1;
        }
        if(shoot && !joyshoot.Pressed)
        {
            shoot = false;
        }
        if(!juump && joybutton.Pressed && jumpCount == 1)
        {
            juump = true;
            Jump();
            jump += 1;
        }
        if(juump && !joybutton.Pressed)
        {
            juump = false;
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
            lastScore = (limit/playTime)+lastScoreEnemy-shots;
            PlayerPrefs.SetInt("temp",lastScore);
        }
    }
}
