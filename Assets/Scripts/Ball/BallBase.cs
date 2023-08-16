using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public Vector3 ballSpeed = new Vector3(1, 1, 0);
    private Vector3 startSpeed;
    public string keyToCheck = "Player";


    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector3 _startPosition;

    private bool _canMove = false;
    private void Awake()
    {
        _startPosition = transform.position;
        startSpeed = ballSpeed;
    }

    void Update()
    {
        if (!_canMove) return;
        transform.Translate(ballSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == keyToCheck)
            OnPlayerCollision();
        else

            ballSpeed.y *= -1;
    }

    private void OnPlayerCollision()
    {
        ballSpeed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);


        if (ballSpeed.x < 0)
            rand = -rand;

        ballSpeed.x = rand;


        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        ballSpeed.y = rand;
    }

    public void ResetBallPosition()
    {
        transform.position = _startPosition;
        ballSpeed = startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
