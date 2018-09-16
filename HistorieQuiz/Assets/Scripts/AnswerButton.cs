﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {


    public Text answerText;
    // Use this for initialization
    private AnswerData answerData;
    private GameController gameController;


	void Start () {


        gameController = FindObjectOfType<GameController>();


	}

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;

    }
	

    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);

    }
}
