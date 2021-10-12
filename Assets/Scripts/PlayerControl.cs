using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;

    public float speed;
    public float yBoundary = 9f;
    private Rigidbody2D rb2d;
    private int score;

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        playerMovement();
        checkBoundary();
    }

    public void checkBoundary()
    {
        Vector2 position = transform.position;

        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        } 
        else if(position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;
    }

    public void playerMovement()
    {
        Vector2 velocity = rb2d.velocity;

        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0f;
        }

        rb2d.velocity = velocity;
    }

    public void incrementScore()
    {
        score++;
    }

    public void resetScore()
    {
        score = 0;
    }

    public int Score
    {
        get { return score; }
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    //rekam titik collision player dengan ball
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
