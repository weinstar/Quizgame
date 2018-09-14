using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public Question[] allQuestions;
    public List<Question> unansweredQuestions;

    public Question currentQuestion;

    public GameObject Questiontext;
    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    public Button Answer4;



    // Use this for initialization
    void Start () {

         if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = new List<Question>();
            unansweredQuestions.AddRange(allQuestions);

        }

        Answer1.onClick.AddListener(TaskOnClick);
        Answer2.onClick.AddListener(TaskOnClick);
        Answer3.onClick.AddListener(TaskOnClick);
        Answer4.onClick.AddListener(TaskOnClick);


        currentQuestion = unansweredQuestions[Random.Range(0, unansweredQuestions.Count)];


        Questiontext.GetComponentInChildren<Text>().text = currentQuestion.Qtext;
        Answer1.GetComponentInChildren<Text>().text = currentQuestion.answers[0].ToString();
        Answer2.GetComponentInChildren<Text>().text = currentQuestion.answers[1].ToString();
        Answer3.GetComponentInChildren<Text>().text = currentQuestion.answers[2].ToString();
        Answer4.GetComponentInChildren<Text>().text = currentQuestion.answers[3].ToString();




    }

    private void TaskOnClick()
    {
        
    }

    // Update is called once per frame
    void Update () {
	
        
        	
	}
}
