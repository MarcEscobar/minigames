﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_src : MonoBehaviour {



    //Private
    private GameManager gameManager;
    private float startTime;
    private float distanceTototalDistanceToDestination;
    private bool isJumping;
    private bool isFalling;
    private Vector3 initPos;
    private int direction;
    private float rotationCicleCount;
    private float circularSpeed;
    private float circularHeight;
    private float circularWidth;

    //Public
    public GameObject endPosition;
    public float jumpSpeed;



    public void init(GameManager gm)
    {
        gameManager = gm;
    }


    void Start () {
        //circular
        circularSpeed = 2;
        circularHeight = 10;
        circularWidth = 10;

        direction = 1;
        initPos = transform.position;
        isJumping = false;
        startTime = Time.time;
        distanceTototalDistanceToDestination = Vector3.Distance(transform.position, endPosition.transform.position);
    }

	void Update () {
        //InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)

        if (Input.GetKeyDown(KeyCode.Space)) //el perro salta
        {
            isJumping = true;
        }

        if (isJumping)
        {
            float currentDuration = (Time.time - startTime);
            float journeyFraction = currentDuration / distanceTototalDistanceToDestination;
            transform.position = Vector3.Lerp(transform.position, endPosition.transform.position, journeyFraction);
            if(Vector3.Distance(transform.position, endPosition.transform.position) <= 3)
            {
                isJumping = false;
            }
        }

        /*if(win)
           {
               Debug.Log("WIN");
               gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
           }
           else
           {
               gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
           }*/

    }

}