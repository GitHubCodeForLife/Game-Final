using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Animator animator;
    public Rigidbody2D rigidbody2d;
    private float horizontal;

    public Transform groundSensor;
    public GameObject dustEffect;

    private int jumpStep;
    public float jumpForce = 5f;
    public int defaultJumpStep = 2;
    private void Awake()
    {
        jumpStep = defaultJumpStep;
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        PlayerJump();    
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerMoveKeyBoard();
    }
    void PlayerMoveKeyBoard() {
        Vector3 pos = transform.position;
        pos += new Vector3(horizontal, 0f, 0f) * speed * Time.deltaTime;
        transform.position = pos;
    }
    void AnimatePlayer()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            //transform.rotation = new Quaternion(0, 0, 0,0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            animator.SetFloat("Speed", -1);
        }
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpStep > 0)
        {
            AudioManager.instance.PlayOneShot("Player_Jump");
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
        jumpStep = defaultJumpStep;
        Instantiate(dustEffect, groundSensor.position, groundSensor.rotation);
    }
}


