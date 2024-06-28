using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool vertical;

    Rigidbody2D rb;
    float speed = 2f;
    float changeTime = 3f;
    float timer;
    int direction = 1;

    private void Start()
    {
        timer = changeTime;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            direction = -direction;
            timer = changeTime;
            vertical = RandomMove();
        }
    }
    private void FixedUpdate()
    {
        if (vertical)
        {
            rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * speed * direction);
        }
        else
        {
            rb.MovePosition(rb.position + Vector2.left * Time.fixedDeltaTime * speed * direction);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    private bool RandomMove()
    {
        int random = Random.Range(0, 2);
        if (random ==1)
        {
            return vertical;
        } else
        {
            return !vertical;
        }
    }
}
