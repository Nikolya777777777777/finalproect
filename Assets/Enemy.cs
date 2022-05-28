using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int count;

    public float speed;
    public Vector3[] positions;

    private int curentTarget;


    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[curentTarget], speed);

        if(transform.position == positions[curentTarget])
        {
            if(curentTarget < positions.Length - 1)
            {
                curentTarget++;
            }else
            {
                curentTarget = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().SpeedBonus();
            collision.GetComponent<Player>().AddCoin(count);
            Destroy(gameObject);
        }
    }
}
