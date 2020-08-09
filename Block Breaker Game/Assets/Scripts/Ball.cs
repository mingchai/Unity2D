﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f, yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
      paddleToBallVector = transform.position - paddle1.transform.position;
      myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
  {
    if(!hasStarted){
      Debug.Log($"hasStarted ={hasStarted}");
      LockBallToPaddle();
      LaunchOnMouseClick();
    }
  }

  private void LaunchOnMouseClick()
  {
    if(Input.GetMouseButtonDown(0)){
      hasStarted = true;
      GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
    }
  }

  private void LockBallToPaddle()
  {
    Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
    transform.position = (paddlePos + paddleToBallVector);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(hasStarted){
      AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
      myAudioSource.PlayOneShot(clip);
      // PlayOneShot ensures the audio plays all the way through rather than getting interrupted, which Play() allows
    }
  }
}
