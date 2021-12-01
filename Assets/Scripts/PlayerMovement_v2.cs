using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_v2 : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer sr;
    private float inputX;

    public Transform attackPoint;
    public Transform groundSensor;
    public GameObject dustEffect;


    //Jump
    private int jumpStep = 2;
    public float jumpForce = 5f;

    private void Awake()
    {
        jumpStep = 2;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyBoard()
    {
        // -- Handle input and movement --
        inputX = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos += new Vector3(inputX, 0f, 0f) * speed * Time.deltaTime;
        transform.position = pos;

    }
    void AnimatePlayer()
    {
        animator.SetFloat("Speed", Mathf.Abs(inputX));
        if (inputX > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
          
        }
        else if (inputX < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);

         
        }
        else
        {
            animator.SetFloat("Speed", -1);

        }
    }
    //void PlayerDoubleJump()
    //{
    //    int jumpStep = 0;
    //    if (Input.GetKeyDown(KeyCode.Space)&&jumpStep!=2)
    //    {
    //        jumpStep++;
    //        animator.SetBool("IsJump", true);
    //        rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    //    }
    //    if(rigidbody2d.velocity.y <= 0)
    //        animator.SetBool("IsJump", false);

    //}

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpStep>0)
        {
            Instantiate(dustEffect, groundSensor.position, groundSensor.rotation);
            animator.SetBool("IsJump", true);
            rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpStep--; 
        }
        if (rigidbody2d.velocity.y <= 0)
            animator.SetBool("IsJump", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpStep = 2;
    }

}
