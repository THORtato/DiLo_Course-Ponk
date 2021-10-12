using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        RestartGame();
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;

        rb2d.velocity = Vector2.zero;
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0, 2);

        if(randomDirection < 1f)
        {
            rb2d.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized);
        }
        else
        {
            rb2d.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized);
        }
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

}
