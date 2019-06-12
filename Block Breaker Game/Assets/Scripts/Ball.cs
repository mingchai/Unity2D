﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    // state
    Vector2 paddleToBallVector;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        // "Keep the ball above the paddle by X units" - the difference between the position of the ball & the position of the paddle, based on our putting the ball above the paddle in the editor.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
        // "Change the position of the ball as the paddle moves" - the paddle will only have it's x-coordinate changing, so just update the x-coordinate as the paddle moves. We still include the y-coordinate as the expected value is a vector
    }
}
