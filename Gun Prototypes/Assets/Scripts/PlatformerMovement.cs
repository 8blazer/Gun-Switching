using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    float timer = 0;
    bool timerGoing = false;
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (moveX > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (moveX < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0));
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            NotGrounded();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Grounded();
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        NotGrounded();
    }
    public void Grounded()
    {
        grounded = true;
    }

    public void NotGrounded()
    {
        grounded = false;
    }
}



