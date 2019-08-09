using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public float speed = 10f;
    public float jump = 10f;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerRenderer;
    private Animator anim;

    Vector3 movement;
    int jumpCount = 1;
    bool isGround = true;

    private AudioSource audio;
    public AudioClip jumpSound;


    // Use this for initialization
    void Start () {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = jumpSound;
        audio.loop = false;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();

        jumpCount = 1;

        isGround = true;
    }
	

	void Update ()
    {
 
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            playerRenderer.flipX = false;    // flip Left

            anim.SetTrigger("Run");
            //Debug.Log("Trigger Run");
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            playerRenderer.flipX = true;   // flip Right

            anim.SetTrigger("Run");
            //Debug.Log("Trigger Run");
        }
        else
        {
            anim.SetTrigger("Idle");
            //Debug.Log("Trigger Idle");
        }


        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (isGround)
        {
            jumpCount = 1;
            if (Input.GetKeyDown("space")) 
            {
                if (jumpCount == 1)
                {
                    Vector2 jumpVelociy = new Vector2(0, jump);
                    playerRigidbody.AddForce(jumpVelociy, ForceMode2D.Impulse);
                    isGround = false;
                    jumpCount = 0;
                    audio.Play();
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {          
            isGround = true;
            jumpCount = 1; 
        }


    }



}