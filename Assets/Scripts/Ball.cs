using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool inPlay;
    public Transform Paddle;
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] bool hasStarted = false;
    [SerializeField] Rigidbody2D rb;
    Vector2 paddleToBallVector;
    public GameManager gm; 

    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    private void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchToPaddle();
        }
    }

    private void LaunchToPaddle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.simulated = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }


    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bottom")) {
            Debug.Log("Haha frajer");
            rb.velocity = Vector2.zero;
            hasStarted = false;
            gm.UpdateLives(-1);
        }
    }
}