using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public float speed = 10f;
    public float jump = 10f;

    private Rigidbody2D playerRigidbody;

    Vector3 movement;
    bool isJumping = false;

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
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
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (!isJumping)
        {
            return;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;

            Vector2 jumpVelociy = new Vector2(0, jump);
            playerRigidbody.AddForce(jumpVelociy, ForceMode2D.Impulse);

            isJumping = false;
        }
    }

}
