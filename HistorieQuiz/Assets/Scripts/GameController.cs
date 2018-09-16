using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerBottonParent;

    public Text questionText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;

    public GameObject questionDisplay;
    public GameObject RoundEndDisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>(); 


    // Use this for initialization
	void Start () {

        dataController = FindObjectOfType<DataController> ();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;

        playerScore = 0;
        questionIndex = 0;


        isRoundActive = true;

        ShowQuestion();

        UpdateTimeRemainingDiplay();


    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();

        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;


        for (int i = 0; i < questionData.answers.Length; i++)
        {

            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();

            answerButtonGameObject.transform.SetParent(answerBottonParent);
            answerButtonGameObjects.Add(answerButtonGameObject);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);



        }



    }
	
    public void AnswerButtonClicked(bool isCorrect)
    {
        if(isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();



        }

        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();



        }
        else
        {
            EndRound();

        }



    }

    public void EndRound()
    {
        isRoundActive = false;
        questionDisplay.SetActive(false);
        RoundEndDisplay.SetActive(true);

    }

        
    public void ReturnToMenu ()
    {
        SceneManager.LoadScene("MenuScreen");

    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {

            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);


        }

    }

    private void UpdateTimeRemainingDiplay()
    {

        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

	// Update is called once per frame
	void Update () {

        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDiplay();

            if(timeRemaining <= 0f)
            {
                EndRound();

            }

        }


	}
}
