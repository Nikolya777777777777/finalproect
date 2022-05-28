using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float speedBonus;
    public float jumpForce;

    private float speedStart;

    public bool isGrounded;

    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRender;
    private Animator animator;

    public int score;
    public Text scoreText;

    public float timerSpeed;
    public float timerSpeedMax;

    public float timerScale;
    public float timerScaleMax;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


        speedStart = speed;



        scoreText.text = score.ToString();
    }

    private void BonusCheck()
    {

        if (timerSpeed > 0)
        {
            speed = speedBonus;

            timerSpeed--;
        }
        else
        {
            speed = speedStart;
        }
        if (timerScale > 0)
        {
            transform.localScale = new Vector3(12f, 12f, 1);

            timerScale--;
        }
        else
        {
            transform.localScale = new Vector3(9, 9, 1);
        }
    }
    public void SpeedBonus ()
    {
        timerSpeed = timerSpeedMax;
    }


    public void ScaleBonus()
    {
        timerScale = timerScaleMax;
    }


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();

        }



        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;

        transform.position = position;


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRender.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRender.flipX = false;
            }

            animator.SetInteger("State", 1);
        }else
        {
            animator.SetInteger("State", 0);
        }

        BonusCheck();



    }


    private void Jump()
        {
            rigidbody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    
    public void AddCoin(int count)
    {
        score += count;

        scoreText.text = score.ToString();

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
