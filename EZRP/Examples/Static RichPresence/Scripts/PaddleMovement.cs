using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 1;

    void Update()
    {
        rb2d.velocity = new Vector2(0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }
}
