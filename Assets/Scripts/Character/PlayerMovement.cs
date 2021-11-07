using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer sr;
    private float inputX;

    public Transform attackPoint;

    //Jump
    private bool isGrounded = true;
    public float jumpForce = 5f;

    public int direction = 1;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        direction = transform.localScale.x <= 0 ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyBoard() {
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
            transform.localScale = new Vector3(1f, 1f, 1.0f);
            direction = 1;
            //rigidbody2d.rotation = 180;
            // transform.rotation = 
            //sr.flipX = false;
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1.0f);
            //rigidbody2d.rotation = 0;
            direction = -1;
            //   sr.flipX = true;
        }
        else
        {
            animator.SetFloat("Speed", -1);
            
        }
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            animator.SetBool("IsJump", true);
            rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        if(rigidbody2d.velocity.y <= 0)
            animator.SetBool("IsJump", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

}

