using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpHeight = 3.0f;
    public bool isOnGround = false;
    int jumpcount = 1;
    public int jumptest = 1;
    
    public static int hp;
    //public Text health;


    void Start()
    {

    }
    void Update()
    {
        //health.text = "HEALTH: " + hp;
        float movex = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = movex * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && jumptest > 0)
        {
            Jump();
        }
        float x = Input.GetAxisRaw("Horizontal");
        if (velocity.x > 0)
        {
            Quaternion transfer = GetComponent<Transform>().rotation;
            transfer.y = 0;
            GetComponent<Transform>().rotation = transfer;

        }
        if (velocity.x < 0)
        {
            Quaternion transfer = GetComponent<Transform>().rotation;
            transfer.y = -180;
            GetComponent<Transform>().rotation = transfer;

        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
    public void Jump()
    {
        if (jumptest == jumpcount)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpHeight));
            jumptest -= 1;
        }
        else
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = 0;
            GetComponent<Rigidbody2D>().velocity = velocity;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 75 * jumpHeight));
            jumptest -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 0)
        {
            isOnGround = true;
            jumptest = jumpcount;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            isOnGround = true;
            jumptest = jumpcount;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 0)
        {
            isOnGround = false;
            jumptest -= 1;
        }
    }
}
