using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Floats
    public float walkSpeed = 5f;
    public float jumpPower = 3f;

    //Audio
    public AudioSource laserSFX;

    //Bool
    bool isGrounded;

    //Editor
    public Transform groundCheck;
    public Transform groundCheck_L;
    public Transform groundCheck_R;
    public GameObject laser;
    public Transform laserSpawn;

    //Player Components
    Animator anim;
    Rigidbody2D playerRB;
    SpriteRenderer playerSR;

    //Private
    private CameraShake shake;


    // Start is called before the first frame update
    void Start()
    {
        //Access player's components
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player can only shoot while grounded (can't shoot while jumping)
        if (isGrounded)
            {
                //If player presses Left Click
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //Spawn laser
                    Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
                    //Access camera shake animation from CameraShake.cs script
                    shake.CamShake();
                    //Play laser audio
                    laserSFX.Play();
                }
            }
  
    }

    private void FixedUpdate()
    {
        //Drawing a line cast to check if player is touching ground
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheck_L.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheck_R.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            //Player is grounded
            isGrounded = true;
        }
        else
        {
            //Player is not grounded
            isGrounded = false;
            //When player is not grounded, play jump/fall animation
            anim.Play("Player_Jump");
        }

        //If user presses D key, player will move right
        if(Input.GetKey(KeyCode.D))
        {
            //moves player
            playerRB.velocity = new Vector2(walkSpeed, playerRB.velocity.y);
            if (isGrounded)
            {             
                //plays animation
                anim.Play("Player_GunRun");
            }
            //back to facing right
            playerSR.flipX = false;
        }
        //If user presses A key, player will move left
        else if (Input.GetKey(KeyCode.A))
        {
            //moves player
            playerRB.velocity = new Vector2(-walkSpeed, playerRB.velocity.y);
            if (isGrounded)
            {
                //plays animation
                anim.Play("Player_GunRun");
            }
            //sprite faces left
            playerSR.flipX = true;
        }
        //Else if the player stops moving...
        else
        {
            if (isGrounded)
            {
                //Play idle animation
                anim.Play("Player_IdleGun");
            }
            //If player has stopped moving, velocity is now null
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        //If user presses Space, player will jump upwards
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
            anim.Play("Player_Jump");
        }
    }
}
