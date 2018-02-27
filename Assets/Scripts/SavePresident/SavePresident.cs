﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SavePresident : IMiniGame
{

    public GameObject agent;
    public GameObject agentTargetPos;
    private GameManager gameManager;
    public Text myText;
    public int countdown;

    public GameObject slider;


    public AudioSource agentSound;
    bool moveAgent;

    bool toWin;

    void Start()
    {
        StartCoroutine(countToDie());
        moveAgent = false;
        myText.text = ""+ countdown;
    }

    void Update()
    {
        if(countdown <= 0)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }

        if (moveAgent)
        {
                agent.GetComponent<Animation>().Play();
            toWin = true;
        }

        toWin = slider.GetComponent<checkTrigger>().win;

        if (toWin)
        {
            StartCoroutine(Winner());

        }

    }

    IEnumerator countToDie()
    {
        yield return new WaitForSeconds(1);
        if (countdown >= 0)
        {
            countdown--;
        }
        StartCoroutine(countToDie());
    }

    IEnumerator Winner()
    {
        moveAgent = true;
        agentSound.Play();
        yield return new WaitForSeconds(3);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override void beginGame()
    {
        //keyToPress.text = "Press the magic button fast!";
    }
}
