using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : BaseController 
{
    private Rigidbody myBody;

    public Transform bullet_Startpoint;
    public GameObject bullet_Prefab;
    public ParticleSystem shootFX;

    private Animator shootSliderAnim;

    [HideInInspector]
    public bool canShoot;

    void Start()
    {
        myBody = GetComponent<Rigidbody>(); 
        shootSliderAnim = GameObject.Find("Fire Bar").GetComponent<Animator>();
        GameObject.Find("ShootBtn").GetComponent<Button>().onClick.AddListener(ShootingControl);
        canShoot=true;
    }

    
    // Update is called once per frame
    void Update()
    {
        keyboardcontrol();
        ChangeRotation();
    }

    private void FixedUpdate()
    {
        MoveTank();
        
    }

    void MoveTank()
    {
        myBody.MovePosition(myBody.position + speed*Time.deltaTime);
    }

    void keyboardcontrol()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            moveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            moveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveFast();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            moveStraight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            moveStraight();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            moveNormal();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            moveNormal();
        }

    }

    void ChangeRotation()
    {
        if (speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }
        else if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        } else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f,0f ,0f), Time.deltaTime * rotationSpeed);
        }

    }

    public void ShootingControl()
    {
        if (Time.timeScale != 0)
        {
            if(canShoot)
            {
                GameObject bullet = Instantiate(bullet_Prefab, bullet_Startpoint.position, Quaternion.identity);
                bullet.GetComponent<BulletScript>().Move(2000f);
                shootFX.Play();

                canShoot = false;
                shootSliderAnim.Play("Fill");

            }

        }
        
    }
}
