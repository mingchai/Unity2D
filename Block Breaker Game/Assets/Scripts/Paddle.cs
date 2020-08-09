﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits= 16f;
    [SerializeField] float minX = 1f, maxX = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePosX, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosX, minX, maxX);
        transform.position = paddlePos;
    }
}
