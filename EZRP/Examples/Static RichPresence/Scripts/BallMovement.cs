using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel.Design;

public class BallMovement : MonoBehaviour
{
    public Vector2 dir;
    public Rigidbody2D rb;
    public int score;
    public float speed;
    public float initspeed;
    bool didchange;
    public TextMeshProUGUI ScoreText;
    public AudioSource Wall;
    public AudioSource Paddle;
    public EnemyPaddle ep;
    // Start is called before the first frame update
    void Start()
    {
        initspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE: " + score;
        rb.velocity = new Vector2(dir.x, dir.y) * speed;
        if(didchange is false && score % 10 == 0)
        {
            didchange = true;
            speed += 1;
            ep.speed += 1;
        }
        if(score % 10 != 0)
        {
            didchange = false;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            dir.x = dir.x * (-1);
            score += 1;
            Paddle.Play();
        }
        if (collision.transform.CompareTag("Wall"))
        {
            dir.y = dir.y * (-1);
            Wall.Play();
        }
        if (collision.transform.CompareTag("Finish"))
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.position = new Vector2(0, 0);
        score = 0;
        dir = new Vector2(1, 1);
        speed = initspeed;
        ep.speed = 4;
    }
}
