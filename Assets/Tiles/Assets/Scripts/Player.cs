using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isGrounded;
    private Rigidbody2D rigidbody2d;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;

        transform.position = position;

    }
    private void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rigidbody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }

    }


